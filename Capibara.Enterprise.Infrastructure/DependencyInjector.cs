using Capibara.Enterprise.Core.API.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Infrastructure;

public static class DependencyInjector
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
    {
        services.InjectAllFromRootType(typeof(DependencyInjector));
        return services;
    }
}