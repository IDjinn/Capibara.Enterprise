using Capibara.Enterprise.Core.API.Hotel.Users;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Users;

[Inject(ServiceLifetime.Scoped)]
internal sealed record Habbo : IHabbo
{
    public Habbo(ISocketClient client, HabboProfileInfo profileInfo)
    {
        Client = client;
        ProfileInfo = profileInfo;
    }

    public HabboProfileInfo ProfileInfo { get; }

    public uint Cash { get; }

    public ISocketClient Client { get; }
}