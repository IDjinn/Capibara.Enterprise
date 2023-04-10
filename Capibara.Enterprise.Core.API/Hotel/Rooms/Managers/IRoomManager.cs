namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Managers;

public interface IRoomManager : IAsyncDisposable
{
    public ValueTask InitAsync(IRoom room);
}