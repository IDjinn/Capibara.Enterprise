using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;

namespace Capibara.Enterprise.Core.Hotel.Rooms.Entities;

public abstract record RoomEntity
    (RoomEntityId Id, EntityData Data, Coordinate Coordinate, Direction BodyDirection) : IRoomEntity;