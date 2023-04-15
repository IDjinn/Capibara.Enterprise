namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Managers;

public interface IRoomManager
{
    public IReadOnlyDictionary<RoomId, IRoom> LoadedRooms { get; }
    public ValueTask<IRoom> Load(RoomId roomId);
    public bool IsLoaded(RoomId roomId);
}