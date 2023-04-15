namespace Capibara.Enterprise.Core.API.Hotel.Rooms;

public interface IRoomFactory
{
    public IRoom Create(RoomData roomData);
}