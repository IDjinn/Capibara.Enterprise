using System.Data;

namespace Capibara.Enterprise.Infrastructure.API.Database;

public interface IDbConnectionFactory
{
    public IDbConnection CreateConnection();
}