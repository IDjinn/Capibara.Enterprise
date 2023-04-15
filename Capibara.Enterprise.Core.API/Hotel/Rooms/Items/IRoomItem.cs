using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;

namespace Capibara.Enterprise.Core.API.Hotel.Rooms.Items;

public readonly record struct RoomItemId(ulong Id)
{
    public override string ToString()
    {
        return Id.ToString();
    }
}

public interface IRoomItem
{
    public RoomItemId ItemId { get; }
    public Coordinate Coordinates { get; }
}