using Capibara.Enterprise.Core.API.Hotel.Rooms.Managers;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Managers.Chunks;

namespace Capibara.Enterprise.Core.API.Hotel.Rooms;

public readonly record struct RoomId(ushort Id);

public interface IRoom : IAsyncDisposable
{
    public RoomId Id { get; }
    public bool IsReady { get; }
    public IRoomEntityManager EntityManager { get; }
    public IRoomChunkManager ChunkManager { get; }
    public ValueTask Initialize();
}