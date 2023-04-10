using Capibara.Enterprise.Core.API.Hotel.Common;

namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;

public sealed record EntityData(
    RoomEntityId Id,
    string Nickname,
    string Motto,
    Figure Figure,
    EntityType EntityType
);