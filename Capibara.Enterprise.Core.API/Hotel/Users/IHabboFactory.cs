using Capibara.Enterprise.Core.API.Networking;

namespace Capibara.Enterprise.Core.API.Hotel.Users;

public interface IHabboFactory
{
    public IHabbo Create(HabboProfileInfo profileInfo, ISocketClient client);
}