using Capibara.Enterprise.Core.API.Util;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Presentation.RawSockets;

public static class DependencyInjector
{
    public static IServiceCollection AddRawSockets(this IServiceCollection services)
    {
        services.InjectAllFromRootType(typeof(DependencyInjector));
        return services;
    }
}