using Capibara.Enterprise.Core.API.Hotel.Rooms.Components;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;

namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Managers;

public interface IRoomEntityManager : IAsyncDisposable, IRoomComponent
{
    public IReadOnlyDictionary<RoomEntityId, IRoomEntity> LoadedEntities { get; }

    public TRoomEntity? GetEntity<TRoomEntity>(RoomEntityId id) where TRoomEntity : IRoomEntity;
    public IRoomEntity? GetEntityByName(string name);
}