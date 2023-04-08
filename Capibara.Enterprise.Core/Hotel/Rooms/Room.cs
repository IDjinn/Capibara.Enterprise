using Capibara.Enterprise.Core.API.Hotel.Rooms;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Rooms;

[Inject(ServiceLifetime.Scoped)]
public sealed record Room(
    IRoomEntityManager EntityManager
) : IRoom;