using System.Diagnostics;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Networking.Common;
using Capibara.Enterprise.Core.API.Networking.Common.Packets;
using Capibara.Enterprise.Core.API.Networking.Sockets;
using Capibara.Enterprise.Core.API.Util;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Capibara.Enterprise.Networking.Packets.Interceptors;

[Inject(ServiceLifetime.Singleton)]
public class CrossdomainInterceptor : IPacketInterceptor
{
    private static readonly byte[] CrossdomainPolicy =
        "<?xml version=\"1.0\"?>\n  <!DOCTYPE cross-domain-policy SYSTEM \"/xml/dtds/cross-domain-policy.dtd\">\n  <cross-domain-policy>\n  <allow-access-from domain=\"*\" to-ports=\"*\" />\n   </cross-domain-policy>\0"u8
            .ToArray();

    private readonly ILogger<CrossdomainInterceptor> _logger;
    private readonly IPacketManager _packetManager;

    public CrossdomainInterceptor(IPacketManager packetManager, ILogger<CrossdomainInterceptor> logger)
    {
        _packetManager = packetManager;
        _logger = logger;

        _packetManager.OnPacketReceive += Intercept;
    }

    public void Intercept(IPacketReader reader, CancellationTokenSource cancellationTokenSource, ISocketClient client)
    {
        Debug.Assert(!client.IsAuth);
        if (reader.Data[0] == Convert.ToByte('<'))
        {
            _logger.Debug("Request for crossdomain data...");
            client.Send(CrossdomainPolicy);
            _logger.Debug("Crossdomain data done!");
            cancellationTokenSource.Cancel();
        }
    }

    public void Dispose()
    {
        _packetManager.OnPacketReceive -= Intercept;
    }
}