using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Items;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Core.API.Util.Interfaces;
using Capibara.Enterprise.Core.Hotel.Rooms.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Core.Hotel.Rooms.Serializers;

[Inject(ServiceLifetime.Singleton)]
public class RoomItemSerializer : ISqlSerializer<IRoomItem>
{
    public IRoomItem? FromDictionary(IDictionary<string, object> row)
    {
        if (row.Count == 0)
            return null;

        var x = row["x"];
        var y = row["y"];
        var z = row["z"];
        var coords = new Coordinate((uint)x, (uint)y, (double)z);
        var itemId = new RoomItemId((ulong)row["item_id"]);
        return new RoomItem(itemId, coords);
    }

    public object ToAnonymousObject(IRoomItem value)
    {
        return new
        {
            itemId = value.ItemId.Id,
            x = value.Coordinates.X,
            y = value.Coordinates.Y,
            z = value.Coordinates.Z
        };
    }
}