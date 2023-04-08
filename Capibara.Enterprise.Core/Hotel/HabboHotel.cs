using Capibara.Enterprise.Core.API.Hotel;
using Capibara.Enterprise.Core.API.Networking.Sockets;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel;

[Inject(ServiceLifetime.Singleton)]
internal class HabboHotel : IHabboHotel
{
    private readonly ISocketManager _socketManager;

    public HabboHotel(ISocketManager socketManager)
    {
        _socketManager = socketManager;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _socketManager.StartAsync(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _socketManager.StartAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        await _socketManager.DisposeAsync();
    }
}