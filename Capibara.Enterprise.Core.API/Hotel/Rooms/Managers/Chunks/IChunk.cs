using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;

namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Managers.Chunks;

public interface IChunk : IAsyncDisposable
{
    public ChunkId Id { get; }
    public IRoom Room { get; }

    public IReadOnlyDictionary<RoomEntityId, IRoomEntity> Entities { get; }
}