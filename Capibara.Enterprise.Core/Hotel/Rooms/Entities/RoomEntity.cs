using Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;

namespace Capibara.Enterprise.Core.Hotel.Rooms.Entities;

public abstract record RoomEntity(EntityData EntityData) : IRoomEntity;