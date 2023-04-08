using System.Collections.ObjectModel;
using System.Text;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.API.Networking.Common.Packets;

[Inject(ServiceLifetime.Transient)]
public class PacketReader : IPacketReader
{
    private int _offset;

    public PacketReader(byte[] data, int length)
    {
        _data = data;
        Length = length;

        ResetOffset();
    }

    private byte[] _data { get; }
    public int Length { get; }

    public ReadOnlyCollection<byte> Data => _data.AsReadOnly();


    public int ReadInt()
    {
        return
            (_data[_offset++] << 24) |
            (_data[_offset++] << 16) |
            (_data[_offset++] << 8) |
            _data[_offset++];
    }

    public short ReadShort()
    {
        return (short)((_data[_offset++] << 8) | _data[_offset++]);
    }

    public string ReadString()
    {
        var length = ReadShort();
        var str = Encoding.UTF8.GetString(_data, _offset, length);
        _offset += length;
        return str;
    }

    public bool ReadBool()
    {
        return _data[_offset++] != 0;
    }

    public void ResetOffset()
    {
        _offset = 0;
        ReadInt();
    }
}