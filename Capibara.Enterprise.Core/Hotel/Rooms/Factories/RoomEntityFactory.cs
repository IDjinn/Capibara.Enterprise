using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Factories;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Core.Hotel.Rooms.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Rooms.Factories;

[Inject(ServiceLifetime.Singleton)]
public class RoomEntityFactory : IRoomEntityFactory
{
    private readonly IServiceProvider _provider;

    public RoomEntityFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IRoomEntity Create(RoomEntityId id, EntityData data, Coordinate coords, Direction bodyDirection)
    {
        return ActivatorUtilities.CreateInstance<RoomEntity>(_provider,
            id,
            data,
            coords,
            bodyDirection
        );
    }
}