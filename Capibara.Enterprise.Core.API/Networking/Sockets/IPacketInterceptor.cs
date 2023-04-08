using Capibara.Enterprise.Core.API.Networking.Common.Packets;

namespace Capibara.Enterprise.Core.API.Networking.Sockets;

public interface IPacketInterceptor : IDisposable
{
    public void Intercept(IPacketReader reader, CancellationTokenSource cancellationTokenSource, ISocketClient client);
}