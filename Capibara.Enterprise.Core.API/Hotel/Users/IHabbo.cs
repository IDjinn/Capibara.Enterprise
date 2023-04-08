using Capibara.Enterprise.Core.API.Networking;

namespace Capibara.Enterprise.Core.API.Hotel.Users;

public interface IHabbo
{
    public uint Cash { get; }


    public ISocketClient Client { get; }
}