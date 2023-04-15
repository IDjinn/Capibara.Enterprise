using System.Data;
using Capibara.Enterprise.Core.API.Hotel.Users;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Infrastructure.API.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Infrastructure.Repositories.Users;

[Inject(ServiceLifetime.Singleton)]
public class UserRepository : IUserRepository
{
    private readonly IDbConnection _connection;

    public UserRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async ValueTask<IHabbo?> GetAsync(HabboId id)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<int> UpdateAsync(IHabbo entity)
    {
        return await new ValueTask<int>(10);
    }

    public async ValueTask DeleteAsync(IHabbo entity)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<IEnumerable<IHabbo>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}