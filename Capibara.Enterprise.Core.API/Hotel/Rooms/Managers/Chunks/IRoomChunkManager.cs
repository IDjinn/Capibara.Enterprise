using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;

namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Managers.Chunks;

public interface IRoomChunkManager : IRoomManager
{
    public IRoom Room { get; }
    public IReadOnlyDictionary<ChunkId, IChunk> LoadedChunks { get; }

    public bool IsLoaded(ChunkId chunkId);

    public IChunk? GetLoadedChunk(ChunkId chunkId);

    public IChunk Load(ChunkId chunkId);
    public ValueTask Unload(ChunkId chunkId);
}