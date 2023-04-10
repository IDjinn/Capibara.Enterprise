using Capibara.Enterprise.Core.API.Hotel.Rooms;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Managers;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Managers.Chunks;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Rooms;

[Inject(ServiceLifetime.Scoped)]
public sealed record Room(
    RoomId Id,
    IRoomEntityManager EntityManager,
    IRoomChunkManager ChunkManager
) : IRoom
{
    private volatile bool _isReady;
    public bool IsReady => _isReady;

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public async ValueTask Initialize()
    {
        await EntityManager.Initialize(this);

        _isReady = true;
    }
}