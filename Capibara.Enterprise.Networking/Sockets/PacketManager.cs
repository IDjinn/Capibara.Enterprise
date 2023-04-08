using System.Collections.Concurrent;
using System.Reflection;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Networking.Common;
using Capibara.Enterprise.Core.API.Networking.Common.Packets;
using Capibara.Enterprise.Core.API.Networking.Sockets;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Capibara.Enterprise.Networking.Sockets;

[Inject(ServiceLifetime.Singleton)]
internal sealed class PacketManager : IPacketManager
{
    private readonly IDictionary<short, IncomingPacket> _incomingPackets;
    private readonly IProducerConsumerCollection<IPacketInterceptor> _interceptors;
    private readonly IServiceProvider _provider;

    public PacketManager(ILogger<PacketManager> logger, IServiceProvider provider)
    {
        _provider = provider;
        _interceptors = new ConcurrentBag<IPacketInterceptor>();
        _incomingPackets = new Dictionary<short, IncomingPacket>(100);
        var types = typeof(DependencyInjector).Assembly.GetTypes();
        var packets = types.Where(type => type.GetCustomAttributes<InjectAttribute>().Any());
        foreach (var type in packets)
        {
            if (typeof(IncomingPacket).IsAssignableFrom(type))
            {
                var incoming = Activator.CreateInstance(type) as IncomingPacket;
                _incomingPackets.Add(incoming!.Id, incoming);
            }

            if (typeof(IPacketInterceptor).IsAssignableFrom(type))
                _interceptors.TryAdd((ActivatorUtilities.CreateInstance(provider, type, this) as IPacketInterceptor)!);
        }
    }

    public event IPacketManager.IncomingPacketIntercept? OnPacketReceive;


    public ValueTask ExecuteAsync(IPacketReader reader, CancellationTokenSource cancellationTokenSource,
        ISocketClient client)
    {
        var interceptorCancellationToken = new CancellationTokenSource();
        OnPacketReceive?.Invoke(reader, interceptorCancellationToken, client);
        if (interceptorCancellationToken.IsCancellationRequested)
            return ValueTask.CompletedTask;

        if (!client.IsAuth)
            return ValueTask.CompletedTask;

        var packetId = reader.ReadShort();
        if (!_incomingPackets.TryGetValue(packetId, out var incomingPacket))
            return ValueTask.CompletedTask;

        return incomingPacket.ExecuteAsync(reader, cancellationTokenSource.Token, client.Habbo);
    }
}