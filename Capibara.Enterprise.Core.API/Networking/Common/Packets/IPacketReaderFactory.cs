namespace Capibara.Enterprise.Core.API.Networking.Common.Packets;

public interface IPacketReaderFactory
{
    public IPacketReader Create(byte[] data, int length);
}