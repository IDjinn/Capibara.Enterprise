using Microsoft.Extensions.Hosting;

namespace Capibara.Enterprise.Core.API.Networking.Sockets;

public interface ISocketManager : IHostedService, IAsyncDisposable
{
}