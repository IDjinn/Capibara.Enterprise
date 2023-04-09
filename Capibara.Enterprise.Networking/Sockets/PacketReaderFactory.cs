using Capibara.Enterprise.Core.API.Networking.Common.Packets;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Networking.Packets;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Networking.Sockets;

[Inject(ServiceLifetime.Scoped)]
public class PacketReaderFactory : IPacketReaderFactory
{
    private readonly IServiceProvider _provider;

    public PacketReaderFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IPacketReader Create(byte[] data, int length)
    {
        return ActivatorUtilities.CreateInstance<PacketReader>(_provider, data, length);
    }
}