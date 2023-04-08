using System.Diagnostics;
using System.Reflection;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.API.Util;

public static class DependencyInjectorUtils
{
    public static IServiceCollection InjectAllFromRootType(this IServiceCollection services, Type rootType)
    {
        ArgumentNullException.ThrowIfNull(rootType);

        var typesToInject = rootType.Assembly.GetTypes()
            .Where(type => type.GetCustomAttributes<InjectAttribute>().Any());
        foreach (var type in typesToInject)
        {
            var _interface = type.GetInterfaces().First()!;
            var injectAttribute = type.GetCustomAttributes<InjectAttribute>().First();
            Debug.Assert(_interface is not null);
            Debug.Assert(!type.IsInterface);

            switch (injectAttribute.Lifetime)
            {
                case ServiceLifetime.Scoped:
                {
                    services.AddScoped(_interface, type);
                    break;
                }
                case ServiceLifetime.Singleton:
                {
                    services.AddSingleton(_interface, type);
                    break;
                }
                case ServiceLifetime.Transient:
                {
                    services.AddTransient(_interface, type);
                    break;
                }
            }
        }

        return services;
    }
}