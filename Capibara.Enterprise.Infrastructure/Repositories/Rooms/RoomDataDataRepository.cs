using Capibara.Enterprise.Core.API.Hotel.Rooms;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Infrastructure.API.Repositories.Rooms;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Infrastructure.Repositories.Rooms;

[Inject(ServiceLifetime.Singleton)]
public class RoomDataDataRepository : IRoomDataRepository
{
    public async ValueTask<RoomData?> GetAsync(RoomId id)
    {
        throw new NotImplementedException();
    }


    public async ValueTask<int> UpdateAsync(RoomData entity)
    {
        throw new NotImplementedException();
    }

    public async ValueTask DeleteAsync(RoomData entity)
    {
        throw new NotImplementedException();
    }
}