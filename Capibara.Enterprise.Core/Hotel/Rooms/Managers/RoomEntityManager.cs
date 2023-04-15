using System.Collections.Concurrent;
using Capibara.Enterprise.Core.API.Hotel.Rooms;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Managers;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Rooms.Managers;

[Inject(ServiceLifetime.Scoped)]
public sealed record RoomEntityManager : IRoomEntityManager
{
    private readonly ConcurrentDictionary<RoomEntityId, IRoomEntity> _entities;
    private IRoom _room = null!;

    public RoomEntityManager()
    {
        _entities = new ConcurrentDictionary<RoomEntityId, IRoomEntity>();
    }

    public IReadOnlyDictionary<RoomEntityId, IRoomEntity> LoadedEntities => _entities.AsReadOnly();

    public TRoomEntity? GetEntity<TRoomEntity>(RoomEntityId id) where TRoomEntity : IRoomEntity
    {
        return _entities.TryGetValue(id, out var entity) ? (TRoomEntity)entity : default;
    }

    public IRoomEntity? GetEntityByName(string name)
    {
        return _entities.Values.FirstOrDefault(entity => entity.Data.Nickname == name);
    }

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public ValueTask Initialize(IRoom room)
    {
        _room = room;
        return ValueTask.CompletedTask;
    }
}