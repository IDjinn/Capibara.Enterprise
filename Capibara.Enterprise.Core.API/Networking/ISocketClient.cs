using System.Diagnostics.CodeAnalysis;
using Capibara.Enterprise.Core.API.Hotel.Users;
using Capibara.Enterprise.Core.API.Networking.Common.Packets;
using Capibara.Enterprise.Core.API.Networking.Sockets;

namespace Capibara.Enterprise.Core.API.Networking;

public interface ISocketClient : IDisposable
{
    [MemberNotNullWhen(true, nameof(Habbo))]
    public bool IsAuth { get; }

    public IHabbo? Habbo { get; set; }
    public MachineId? MachineId { get; set; }
    VersionReleaseInfo? VersionRelease { get; set; }
    SsoTicket? SsoTicket { get; set; }
    public Task ListenAsync();

    public void Send(byte[] data);
    public void Send(OutgoingPacket packet);
    public ValueTask SendAsync(OutgoingPacket packet);
}