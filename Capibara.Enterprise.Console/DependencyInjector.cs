using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Console;

public static class DependencyInjector
{
    public static IServiceCollection AddConsole(this IServiceCollection services)
    {
        return services;
    }
}