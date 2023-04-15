using System.Data;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Infrastructure.API.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace Capibara.Enterprise.Infrastructure.Database;

[Inject(ServiceLifetime.Singleton)]
public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _configuration;

    public DbConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("HotelDatabase"));
    }
}