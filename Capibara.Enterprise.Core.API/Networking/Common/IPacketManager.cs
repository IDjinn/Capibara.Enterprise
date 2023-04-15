using Capibara.Enterprise.Core.API.Networking.Common.Packets;

namespace Capibara.Enterprise.Core.API.Networking.Common;

public interface IPacketManager
{
    public delegate void IncomingPacketIntercept(IPacketReader reader, CancellationTokenSource cancellationToken,
        IGameClient client);

    public event IncomingPacketIntercept OnPacketReceive;

    public ValueTask ExecuteAsync(IPacketReader reader, CancellationTokenSource cancellationToken,
        IGameClient client);
}