using Capibara.Enterprise.Core.API.Hotel.Users;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Users;

[Inject(ServiceLifetime.Scoped)]
internal sealed record Habbo(HabboId Id, HabboProfileInfo Profile, IGameClient Client) : IHabbo
{
    public uint Cash { get; }
}