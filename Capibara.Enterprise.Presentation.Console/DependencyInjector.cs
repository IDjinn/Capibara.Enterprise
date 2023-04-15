using Capibara.Enterprise.Core.API.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Presentation.Console;

public static class DependencyInjector
{
    public static ConfigurationManager ConfigureConsole(this ConfigurationManager configurationManager)
    {
        configurationManager
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
        ;
        return configurationManager;
    }

    public static IServiceCollection AddConsole(this IServiceCollection services)
    {
        services.InjectAllFromRootType(typeof(DependencyInjector));
        return services;
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public record Program;
}