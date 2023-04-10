namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Components;

public interface IRoomComponent
{
    ValueTask Initialize(IRoom room);
}