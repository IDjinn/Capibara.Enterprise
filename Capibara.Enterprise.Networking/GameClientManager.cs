using System.Collections.Concurrent;
using System.Collections.Immutable;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Networking;

[Inject(ServiceLifetime.Singleton)]
public class GameClientManager : IGameClientManager
{
    private readonly IProducerConsumerCollection<IGameClient> _clients;

    public GameClientManager()
    {
        _clients = new ConcurrentBag<IGameClient>();
    }

    public event IGameClientManager.ClientConnected? OnClientConnected;
    public IReadOnlyCollection<IGameClient> ConnectedClients => _clients.ToImmutableList();

    public void OnConnection(IGameClient client)
    {
        _clients.TryAdd(client);
        // TODO: SOCKET DISPOSE WHEN DISCONNECT
        OnClientConnected?.Invoke(client);
    }
}