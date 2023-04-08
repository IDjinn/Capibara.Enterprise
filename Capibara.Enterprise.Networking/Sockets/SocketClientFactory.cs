using System.Net.Sockets;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Networking.Sockets;

[Inject(ServiceLifetime.Singleton)]
public class SocketClientFactory : ISocketClientFactory
{
    private readonly IServiceProvider _provider;

    public SocketClientFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public ISocketClient Create(Socket socket)
    {
        return ActivatorUtilities.CreateInstance<SocketClient>(_provider, socket);
    }
}