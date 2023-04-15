namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Managers;

public interface IRoomInitializer : IAsyncDisposable
{
    public ValueTask InitAsync(IRoom room);
}