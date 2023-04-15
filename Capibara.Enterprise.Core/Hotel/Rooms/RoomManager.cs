using System.Collections.Concurrent;
using Capibara.Enterprise.Core.API.Hotel.Rooms;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Managers;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Infrastructure.API.Repositories.Rooms;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Rooms;

[Inject(ServiceLifetime.Singleton)]
public class RoomManager : IRoomManager
{
    private readonly IRoomDataRepository _roomDataRepository;
    private readonly IRoomFactory _roomFactory;
    private readonly ConcurrentDictionary<RoomId, IRoom> _rooms;

    public RoomManager(IRoomFactory roomFactory, IRoomDataRepository roomDataRepository)
    {
        _roomFactory = roomFactory;
        _roomDataRepository = roomDataRepository;
        _rooms = new ConcurrentDictionary<RoomId, IRoom>();
    }

    public IReadOnlyDictionary<RoomId, IRoom> LoadedRooms => _rooms.AsReadOnly();

    public async ValueTask<IRoom> Load(RoomId roomId)
    {
        if (IsLoaded(roomId))
            return _rooms[roomId];

        var data = await _roomDataRepository.GetAsync(roomId);
        ArgumentNullException.ThrowIfNull(data);

        var room = _roomFactory.Create(data);
        _rooms.TryAdd(room.Id, room);
        return room;
    }

    public bool IsLoaded(RoomId roomId)
    {
        return _rooms.ContainsKey(roomId);
    }
}