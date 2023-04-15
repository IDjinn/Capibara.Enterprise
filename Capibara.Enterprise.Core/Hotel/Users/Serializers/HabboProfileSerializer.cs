using Capibara.Enterprise.Core.API.Hotel.Common;
using Capibara.Enterprise.Core.API.Hotel.Common.Enums;
using Capibara.Enterprise.Core.API.Hotel.Users;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Core.API.Util.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Users.Serializers;

[Inject(ServiceLifetime.Singleton)]
public class HabboProfileSerializer : ISqlSerializer<HabboProfileInfo>
{
    public HabboProfileInfo? FromDictionary(IDictionary<string, object> row)
    {
        var id = row["id"];
        var nickname = row["nickname"];
        var gender = row["gender"];
        var figure = row["figure"];
        var motto = row["motto"];
        var registeredAt = DateTime.Parse((string)row["registered_at"]);

        return new HabboProfileInfo(
            new HabboId((uint)id),
            (string)nickname,
            (Gender)(byte)gender,
            new Figure((string)figure),
            (string)motto,
            registeredAt
        );
    }

    public object ToAnonymousObject(HabboProfileInfo value)
    {
        throw new NotImplementedException();
    }
}