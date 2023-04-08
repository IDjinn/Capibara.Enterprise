using System.Diagnostics.CodeAnalysis;
using Capibara.Enterprise.Core.API.Util;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core;

[SuppressMessage("ReSharper", "SwitchStatementHandlesSomeKnownEnumValuesWithDefault")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public static class DependencyInjector
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.InjectAllFromRootType(typeof(DependencyInjector));
        return services;
    }
}