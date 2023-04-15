using Capibara.Enterprise.Core.API.Networking;

namespace Capibara.Enterprise.Core.API.Hotel.Users;

public readonly record struct HabboId(uint Id);

public interface IHabbo
{
    public HabboId Id { get; }
    public HabboProfileInfo Profile { get; }
    public uint Cash { get; }


    public IGameClient Client { get; }
}