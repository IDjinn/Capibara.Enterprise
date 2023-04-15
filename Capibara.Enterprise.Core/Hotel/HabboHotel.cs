using Capibara.Enterprise.Core.API.Hotel;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Managers;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel;

[Inject(ServiceLifetime.Singleton)]
internal class HabboHotel : IHabboHotel
{
    private readonly IEnumerable<IHotelService> _hotelServices;
    private readonly IRoomManager _roomManager;

    public HabboHotel(
        IEnumerable<IHotelService> hotelServices,
        IRoomManager roomManager
    )
    {
        _hotelServices = hotelServices;
        _roomManager = roomManager;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.WhenAll(_hotelServices.Select(service => service.StartAsync(cancellationToken)));
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.WhenAll(_hotelServices.Select(service => service.StopAsync(cancellationToken)));
    }

    public async ValueTask DisposeAsync()
    {
        foreach (var hotelService in _hotelServices) await hotelService.DisposeAsync();
    }
}