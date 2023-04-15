using Capibara.Enterprise.Core.API.Hotel.Users;

namespace Capibara.Enterprise.Core.API.Hotel.Rooms;

public record RoomData(
    RoomId Id,
    string Name,
    HabboId OwnerId
);