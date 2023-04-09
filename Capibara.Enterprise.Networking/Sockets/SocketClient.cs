using System.Buffers;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using Capibara.Enterprise.Core.API.Hotel.Users;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Networking.Common;
using Capibara.Enterprise.Core.API.Networking.Common.Packets;
using Capibara.Enterprise.Core.API.Networking.Sockets;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Capibara.Enterprise.Networking.Sockets;

[Inject(ServiceLifetime.Scoped)]
public class SocketClient : ISocketClient
{
    private readonly ILogger<SocketClient> _logger;
    private readonly IPacketManager _packetManager;
    private readonly IPacketReaderFactory _packetReaderFactory;
    private readonly Socket _socket;
    private volatile CancellationTokenSource _cancellationTokenSource;
    private IHabbo? _habbo;

    private Task _listenerTask;

    public SocketClient(
        ILogger<SocketClient> logger,
        IPacketReaderFactory packetReaderFactory,
        IPacketManager packetManager,
        Socket socket)
    {
        _logger = logger;
        _packetReaderFactory = packetReaderFactory;
        _packetManager = packetManager;
        _socket = socket;

        _cancellationTokenSource = new CancellationTokenSource();
        _listenerTask = ListenAsync();
    }

    public bool IsAuth { get; }
    public IHabbo? Habbo { get; set; }
    public MachineId? MachineId { get; set; }
    public SsoTicket? SsoTicket { get; set; }
    public VersionReleaseInfo? VersionRelease { get; set; }

    public async Task ListenAsync()
    {
        _cancellationTokenSource.Token.ThrowIfCancellationRequested();
        do
        {
            var buffer = ArrayPool<byte>.Shared.Rent(SocketSettings.BUFFER_SIZE);
            var receiveBufferLength =
                await _socket.ReceiveAsync(buffer, SocketFlags.None, _cancellationTokenSource.Token);
            foreach (var reader in SlicePacketsInBuffer(buffer, receiveBufferLength))
            {
#if DEBUG
                var headerId = reader.ReadShort();
                _logger.LogDebug("[->] [{HeaderId}] [{Data}]", headerId,
                    Encoding.ASCII.GetString(reader.Data.Take(receiveBufferLength).ToArray()));
                reader.ResetOffset();
#endif

                await _packetManager.ExecuteAsync(reader, _cancellationTokenSource, this);
            }

            ArrayPool<byte>.Shared.Return(buffer);
        } while (!_cancellationTokenSource.IsCancellationRequested);
    }

    public void Send(byte[] data)
    {
        var sentBytes = _socket.Send(data);
        Debug.Assert(sentBytes == data.Length);
    }

    public void Send(OutgoingPacket packet)
    {
        var data = packet.ToRawData();
        var sentBytes = _socket.Send(data);
        Debug.Assert(sentBytes == data.Length);
    }


    public async ValueTask SendAsync(OutgoingPacket packet)
    {
        var data = packet.ToRawData();
        var sentBytes = await _socket.SendAsync(data);
        Debug.Assert(sentBytes == data.Length);
    }

    public void Dispose()
    {
        _cancellationTokenSource.Cancel();
        _socket.Dispose();
        GC.SuppressFinalize(this);
    }

    private IEnumerable<IPacketReader> SlicePacketsInBuffer(byte[] buffer, int bufferLength)
    {
        var offset = 0;
        do
        {
            var packetSize = HabboPacketReadersHelper.ReadInt(buffer, offset);
            var packetData = new byte[packetSize + sizeof(int)];
            Buffer.BlockCopy(buffer, offset, packetData, 0, packetSize + sizeof(int));
            offset += packetSize + sizeof(int);

            yield return _packetReaderFactory.Create(packetData, packetSize);
        } while (offset < bufferLength);
    }
}