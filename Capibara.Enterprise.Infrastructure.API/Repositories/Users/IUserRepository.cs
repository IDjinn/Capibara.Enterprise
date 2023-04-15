using Capibara.Enterprise.Core.API.Hotel.Users;

namespace Capibara.Enterprise.Infrastructure.API.Repositories.Users;

public interface IUserRepository : IRepositoryBase<HabboId, IHabbo>
{
}