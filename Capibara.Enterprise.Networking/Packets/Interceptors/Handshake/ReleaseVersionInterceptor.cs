using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Networking.Common;
using Capibara.Enterprise.Core.API.Networking.Common.Packets;
using Capibara.Enterprise.Core.API.Networking.Sockets;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Packets.Incoming.Handshake;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Networking.Packets.Interceptors.Handshake;

[Inject(ServiceLifetime.Singleton)]
public class ReleaseVersionInterceptor : IPacketInterceptor
{
    private readonly IPacketManager _packetManager;

    public ReleaseVersionInterceptor(IPacketManager packetManager)
    {
        _packetManager = packetManager;

        _packetManager.OnPacketReceive += Intercept;
    }

    public void Intercept(IPacketReader reader, CancellationTokenSource cancellationTokenSource, ISocketClient client)
    {
        if (cancellationTokenSource.IsCancellationRequested)
            return;

        var headerId = reader.ReadShort();
        if (headerId == HandshakeEventHeaders.ReleaseVersionEvent)
        {
            var production = reader.ReadString();
            var type = reader.ReadString();
            var platform = reader.ReadInt();
            var category = reader.ReadInt();

            var releaseInfo = new VersionReleaseInfo(production, type, platform, category);
            client.VersionRelease = releaseInfo;

            cancellationTokenSource.Cancel();
        }

        reader.ResetOffset();
    }


    public void Dispose()
    {
        _packetManager.OnPacketReceive -= Intercept;
    }
}