using Capibara.Enterprise.Core.API.Hotel.Users;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Networking.Common.Packets;
using Capibara.Enterprise.Core.API.Networking.Sockets;

namespace Capibara.Enterprise.Presentation.WebSockets;

public class WebsocketClient : IGameClient
{
    public bool IsAuth { get; }
    public IHabbo? Habbo { get; set; }
    public MachineId? MachineId { get; set; }
    public VersionReleaseInfo? VersionRelease { get; set; }
    public SsoTicket? SsoTicket { get; set; }

    public async Task ListenAsync()
    {
        throw new NotImplementedException();
    }

    public void Send(byte[] data)
    {
        throw new NotImplementedException();
    }

    public void Send(OutgoingPacket packet)
    {
        throw new NotImplementedException();
    }

    public async ValueTask SendAsync(OutgoingPacket packet)
    {
        throw new NotImplementedException();
    }

    public async ValueTask DisposeAsync()
    {
        await Task.CompletedTask;
    }
}