using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Networking.Common;
using Capibara.Enterprise.Core.API.Networking.Common.Packets;
using Capibara.Enterprise.Core.API.Networking.Sockets;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Packets.Incoming.Handshake;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Networking.Packets.Interceptors.Handshake;

[Inject(ServiceLifetime.Singleton)]
public class MachineIdInterceptor : IPacketInterceptor
{
    private readonly IPacketManager _packetManager;

    public MachineIdInterceptor(IPacketManager packetManager)
    {
        _packetManager = packetManager;

        _packetManager.OnPacketReceive += Intercept;
    }

    public void Intercept(IPacketReader reader, CancellationTokenSource cancellationTokenSource, ISocketClient client)
    {
        if (cancellationTokenSource.IsCancellationRequested)
            return;

        var headerId = reader.ReadShort();
        if (headerId == HandshakeEventHeaders.MachineIdEvent)
        {
            var _ = reader.ReadString();
            var machineId = reader.ReadString();
            client.MachineId = new MachineId(_, machineId);
            cancellationTokenSource.Cancel();
        }

        reader.ResetOffset();
    }

    public void Dispose()
    {
        _packetManager.OnPacketReceive -= Intercept;
    }
}