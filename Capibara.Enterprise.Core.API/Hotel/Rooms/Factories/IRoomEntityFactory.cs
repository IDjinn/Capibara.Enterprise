using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;

namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Factories;

public interface IRoomEntityFactory
{
    IRoomEntity Create(RoomEntityId id, EntityData data, Coordinate coords, Direction bodyDirection);
}