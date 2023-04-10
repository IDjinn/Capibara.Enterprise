using Capibara.Enterprise.Core.API.Hotel.Users;
using Capibara.Enterprise.Core.API.Networking;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Users;

[Inject(ServiceLifetime.Singleton)]
public class HabboFactory : IHabboFactory
{
    private readonly IServiceProvider _provider;

    public HabboFactory(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IHabbo Create(HabboProfileInfo profileInfo, ISocketClient client)
    {
        return ActivatorUtilities.CreateInstance<Habbo>(_provider, profileInfo, client);
    }
}