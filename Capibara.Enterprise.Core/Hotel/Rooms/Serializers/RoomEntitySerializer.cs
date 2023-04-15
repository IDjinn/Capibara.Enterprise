using Capibara.Enterprise.Core.API.Hotel.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Factories;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Core.API.Util.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Rooms.Serializers;

[Inject(ServiceLifetime.Singleton)]
public class RoomEntitySerializer : ISqlSerializer<IRoomEntity>
{
    private readonly IRoomEntityFactory _roomEntityFactory;

    public RoomEntitySerializer(IRoomEntityFactory roomEntityFactory)
    {
        _roomEntityFactory = roomEntityFactory;
    }

    public IRoomEntity? FromDictionary(IDictionary<string, object> row)
    {
        var id = new RoomEntityId((int)row["id"]);
        var data = new EntityData(id,
            (string)row["nickname"],
            (string)row["motto"],
            new Figure((string)row["figure"]),
            (EntityType)(byte)row["type"]
        );

        var coords = new Coordinate((uint)row["x"], (uint)row["y"], (double)row["z"]);
        var direction = (Direction)(byte)row["body_direction"];

        return _roomEntityFactory.Create(id, data, coords, direction);
    }

    public object ToAnonymousObject(IRoomEntity value)
    {
        throw new NotImplementedException();
    }
}