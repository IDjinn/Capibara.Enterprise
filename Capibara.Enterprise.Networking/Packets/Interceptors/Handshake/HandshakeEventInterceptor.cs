using System.Diagnostics;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Networking.Common;
using Capibara.Enterprise.Core.API.Networking.Common.Packets;
using Capibara.Enterprise.Core.API.Networking.Sockets;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Packets.Incoming.Handshake;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Networking.Packets.Interceptors.Handshake;

[Inject(ServiceLifetime.Singleton)]
public class HandshakeEventInterceptor : IPacketInterceptor
{
    private readonly IPacketManager _packetManager;

    public HandshakeEventInterceptor(IPacketManager packetManager)
    {
        _packetManager = packetManager;

        _packetManager.OnPacketReceive += Intercept;
    }

    public void Intercept(IPacketReader reader, CancellationTokenSource cancellationTokenSource, ISocketClient client)
    {
        if (cancellationTokenSource.IsCancellationRequested)
            return;

        Debug.Assert(!client.IsAuth);
        var header = reader.ReadShort();
        if (header == HandshakeEventHeaders.SSoTicketEvent)
        {
            cancellationTokenSource.Cancel();
            var token = reader.ReadString();
            var integer = reader.ReadInt();
            var cypher = reader.ReadString();

            client.SsoTicket = new SsoTicket(token, integer, cypher);
        }

        reader.ResetOffset();
    }

    public void Dispose()
    {
        _packetManager.OnPacketReceive -= Intercept;
    }
}