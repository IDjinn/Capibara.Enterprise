using System.Net.Sockets;

namespace Capibara.Enterprise.Core.API.Networking;

public interface ISocketClientFactory
{
    public ISocketClient Create(Socket socket);
}