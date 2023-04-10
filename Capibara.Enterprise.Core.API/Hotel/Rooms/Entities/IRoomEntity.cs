using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;

namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Entities;

public readonly record struct RoomEntityId(int Id);

public interface IRoomEntity
{
    public RoomEntityId Id { get; }
    public EntityData Data { get; }
    public Coordinate Coordinate { get; }
    public Direction BodyDirection { get; }
}