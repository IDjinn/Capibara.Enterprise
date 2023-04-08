using Capibara.Enterprise.Core.API.Hotel.Users;

namespace Capibara.Enterprise.Core.API.Networking.Common.Packets;

public abstract class IncomingPacket : IPacket
{
    public abstract short Id { get; }
    public abstract ValueTask ExecuteAsync(IPacketReader data, CancellationToken cancellationToken, IHabbo habbo);


    public ValueTask CheckParamsAsync(IPacketReader data, CancellationToken cancellationToken, IHabbo habbo)
    {
        return ValueTask.CompletedTask;
    }


    public ValueTask PreExecuteAsync(IPacketReader data, CancellationToken cancellationToken, IHabbo habbo)
    {
        return ValueTask.CompletedTask;
    }


    public ValueTask PostExecuteAsync(IPacketReader data, CancellationToken cancellationToken, IHabbo habbo)
    {
        return ValueTask.CompletedTask;
    }
}