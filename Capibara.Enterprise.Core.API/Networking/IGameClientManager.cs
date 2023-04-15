namespace Capibara.Enterprise.Core.API.Networking;

public interface IGameClientManager
{
    public delegate void ClientConnected(IGameClient client);

    IReadOnlyCollection<IGameClient> ConnectedClients { get; }
    public void OnConnection(IGameClient client);

    public event ClientConnected OnClientConnected;
}