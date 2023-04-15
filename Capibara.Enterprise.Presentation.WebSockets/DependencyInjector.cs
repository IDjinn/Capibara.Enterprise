using Capibara.Enterprise.Core.API.Util;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Presentation.WebSockets;

public static class DependencyInjector
{
    public static IServiceCollection AddWebSockets(this IServiceCollection services)
    {
        services.InjectAllFromRootType(typeof(DependencyInjector));
        return services;
    }
}