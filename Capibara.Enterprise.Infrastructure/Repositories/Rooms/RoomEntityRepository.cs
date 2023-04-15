using Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Infrastructure.API.Repositories.Rooms;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Infrastructure.Repositories.Rooms;

[Inject(ServiceLifetime.Singleton)]
public class RoomEntityRepository : IRoomEntitiesRepository
{
    public async ValueTask<IRoomEntity?> GetAsync(RoomEntityId id)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<int> UpdateAsync(IRoomEntity entity)
    {
        throw new NotImplementedException();
    }

    public async ValueTask DeleteAsync(IRoomEntity entity)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<IEnumerable<IRoomEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}