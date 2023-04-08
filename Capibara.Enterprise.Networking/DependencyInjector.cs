using Capibara.Enterprise.Core.API.Networking.Sockets;
using Capibara.Enterprise.Core.API.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Networking;

public static class DependencyInjector
{
    public static IServiceCollection AddNetworking(this IServiceCollection services, ConfigurationManager configuration)
    {
        var socketSettings = new SocketSettings();
        configuration.Bind(SocketSettings.SectionName, socketSettings);
        services.Configure<SocketSettings>(configuration.GetSection(SocketSettings.SectionName));
        services.InjectAllFromRootType(typeof(DependencyInjector));
        return services;
    }
}