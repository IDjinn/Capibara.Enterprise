using System.Runtime.CompilerServices;

namespace Capibara.Enterprise.Core.API.Networking.Common;

public static class HabboPacketReadersHelper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static int ReadInt(byte[] data, int offset)
    {
        return
            (data[offset++] << 24) |
            (data[offset++] << 16) |
            (data[offset++] << 8) |
            data[offset];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static short ReadShort(byte[] data, int offset)
    {
        return (short)((data[offset++] << 8) | data[offset]);
    }
}