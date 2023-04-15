using System.Collections.Concurrent;
using System.Diagnostics;
using Capibara.Enterprise.Core.API.Hotel.Rooms;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Managers.Chunks;
using Capibara.Enterprise.Core.API.Util;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Capibara.Enterprise.Core.Hotel.Rooms.Managers;

[Inject(ServiceLifetime.Singleton)]
public sealed class RoomChunkInitializer : IRoomChunkInitializer
{
    private readonly ConcurrentDictionary<ChunkId, IChunk> _chunks;
    private readonly ILogger<RoomChunkInitializer> _logger;

    public RoomChunkInitializer(ILogger<RoomChunkInitializer> logger)
    {
        _logger = logger;
        _chunks = new ConcurrentDictionary<ChunkId, IChunk>();
    }

    public IReadOnlyDictionary<ChunkId, IChunk> LoadedChunks => _chunks.AsReadOnly();
    public IRoom Room { get; private set; } = null!;

    public bool IsLoaded(ChunkId chunkId)
    {
        return _chunks.ContainsKey(chunkId);
    }

    public IChunk? GetLoadedChunk(ChunkId chunkId)
    {
        Debug.Assert(IsLoaded(chunkId), "GetLoadedChunk(ChunkId chunkId) -> IsLoaded(chunkId)");
        if (IsLoaded(chunkId))
            return _chunks[chunkId];

        return null;
    }

    public IChunk Load(ChunkId chunkId)
    {
        Debug.Assert(!IsLoaded(chunkId), "Load(ChunkId chunkId) -> !IsLoaded(chunkId)");

        return null;
    }

    public async ValueTask Unload(ChunkId chunkId)
    {
        Debug.Assert(_chunks.ContainsKey(chunkId), "Unload(ChunkId chunkId) -> _chunks.ContainsKey(chunkId)");
        if (_chunks.TryRemove(chunkId, out var chunk))
            await chunk.DisposeAsync();

        _logger.Debug($"Chunk '{chunkId}' was disposed.");
    }


    public ValueTask InitAsync(IRoom room)
    {
        Room = room;
        return ValueTask.CompletedTask;
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }
}