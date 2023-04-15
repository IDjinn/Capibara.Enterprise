using Capibara.Enterprise.Core.API.Networking;

namespace Capibara.Enterprise.Core.API.Hotel.Users;

public interface IHabboFactory
{
    public IHabbo Create(HabboId id, HabboProfileInfo profileInfo, IGameClient client);
}