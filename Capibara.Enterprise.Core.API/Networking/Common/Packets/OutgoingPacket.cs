namespace Capibara.Enterprise.Core.API.Networking.Common.Packets;

public abstract class OutgoingPacket : IPacket
{
    public abstract short Id { get; }
    public abstract byte[] ToRawData();

    public ValueTask PostExecuteAsync()
    {
        return ValueTask.CompletedTask;
    }
}