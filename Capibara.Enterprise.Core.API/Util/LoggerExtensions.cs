using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace Capibara.Enterprise.Core.API.Util;

public static class LoggerExtensions
{
    [Conditional("DEBUG")]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Debug<T>(this ILogger<T> logger, string? message, params object[] args)
    {
        logger.LogDebug(message, args);
    }
}