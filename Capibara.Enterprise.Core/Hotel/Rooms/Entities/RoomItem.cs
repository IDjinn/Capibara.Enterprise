using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Items;

namespace Capibara.Enterprise.Core.Hotel.Rooms.Entities;

public record RoomItem(
    RoomItemId ItemId,
    Coordinate Coordinates) : IRoomItem
{
}