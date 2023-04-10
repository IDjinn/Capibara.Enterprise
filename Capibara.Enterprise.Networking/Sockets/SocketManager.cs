using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Networking.Sockets;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Capibara.Enterprise.Networking.Sockets;

[Inject(ServiceLifetime.Singleton)]
internal record class SocketManager : ISocketManager
{
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly ISocketClientFactory _clientFactory;

    private readonly IProducerConsumerCollection<ISocketClient> _clients;
    private readonly Socket _listener;
    private readonly ILogger<SocketManager> _logger;
    private readonly SocketSettings _settings;
    private Task? _listenerTask;

    public SocketManager(
        ILogger<SocketManager> logger,
        IOptions<SocketSettings> settings,
        ISocketClientFactory clientFactory)
    {
        _logger = logger;
        _clientFactory = clientFactory;
        _settings = settings.Value;
        _clients = new ConcurrentBag<ISocketClient>();
        _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _cancellationTokenSource = new CancellationTokenSource();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(_settings.Host);
        ArgumentNullException.ThrowIfNull(_settings.Port);
        _listener.Bind(new IPEndPoint(IPAddress.Parse(_settings.Host), _settings.Port));
        _logger.LogInformation("Listening at {host}:{port}", _settings.Host, _settings.Port);

        _listener.Listen(300);
        _listenerTask = Task.Factory.StartNew(async () =>
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
                try
                {
                    var clientSocket = await _listener.AcceptAsync(_cancellationTokenSource.Token);
                    if (clientSocket is null)
                        throw new ArgumentNullException(nameof(clientSocket));

                    _logger.LogInformation("Connection from {Endpoint} recieved",
                        clientSocket?.RemoteEndPoint?.ToString() ?? "unknow endpoint");

                    var client = _clientFactory.Create(clientSocket!);
                    if (!_clients.TryAdd(client)) client.Dispose();
                    // TODO: SOCKET DISPOSE WHEN DISCONNECT
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error accepting connection: {e.Message}");
                    throw;
                }
        }, _cancellationTokenSource.Token);

        await Task.CompletedTask;
    }


    public ValueTask DisposeAsync()
    {
        _listenerTask?.Dispose();
        _cancellationTokenSource.Cancel();
        _listener.Dispose();
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}