using Capibara.Enterprise.Core.API.Hotel.Rooms;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Rooms;

[Inject(ServiceLifetime.Singleton)]
public class RoomFactory : IRoomFactory
{
    private readonly IServiceProvider _provider;

    public RoomFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IRoom Create()
    {
        return ActivatorUtilities.CreateInstance<Room>(_provider);
    }
}