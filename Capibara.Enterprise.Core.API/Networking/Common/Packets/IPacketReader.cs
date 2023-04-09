using System.Collections.ObjectModel;

namespace Capibara.Enterprise.Core.API.Networking.Common.Packets;

public interface IPacketReader
{
    public ReadOnlyCollection<byte> Data { get; }
    public int Offset { get; }
    public int Length { get; }
    int ReadInt();
    short ReadShort();
    string ReadString();
    bool ReadBool();

    void ResetOffset();
}