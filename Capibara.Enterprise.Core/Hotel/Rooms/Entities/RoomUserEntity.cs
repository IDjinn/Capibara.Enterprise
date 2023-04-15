using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;

namespace Capibara.Enterprise.Core.Hotel.Rooms.Entities;

public record RoomUserEntity
    (RoomEntityId Id, EntityData Data, Coordinate Coordinate, Direction BodyDirection) : RoomEntity(Id, Data,
        Coordinate, BodyDirection)
{
}