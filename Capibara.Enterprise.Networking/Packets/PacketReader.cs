using System.Collections.ObjectModel;
using System.Text;
using Capibara.Enterprise.Core.API.Networking.Common;
using Capibara.Enterprise.Core.API.Networking.Common.Packets;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Networking.Packets;

[Inject(ServiceLifetime.Transient)]
public class PacketReader : IPacketReader
{
    public PacketReader(byte[] data, int length)
    {
        _data = data;
        Length = length;

        ResetOffset();
    }

    private byte[] _data { get; }
    public int Offset { get; private set; }
    public int Length { get; }


    public ReadOnlyCollection<byte> Data => _data.AsReadOnly();


    public int ReadInt()
    {
        var value = HabboPacketReadersHelper.ReadInt(_data, Offset);
        Offset += sizeof(int);
        return value;
    }

    public short ReadShort()
    {
        var value = HabboPacketReadersHelper.ReadShort(_data, Offset);
        Offset += sizeof(short);
        return value;
    }

    public string ReadString()
    {
        var length = ReadShort();
        var str = Encoding.UTF8.GetString(_data, Offset, length);
        Offset += length;
        return str;
    }

    public bool ReadBool()
    {
        return _data[Offset++] != 0;
    }

    public void ResetOffset()
    {
        Offset = 0;
        ReadInt();
    }
}