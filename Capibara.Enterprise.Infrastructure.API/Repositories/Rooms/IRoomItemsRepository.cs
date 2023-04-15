using Capibara.Enterprise.Core.API.Hotel.Rooms.Items;

namespace Capibara.Enterprise.Infrastructure.API.Repositories.Rooms;

public interface IRoomItemsRepository : IRepositoryBase<RoomItemId, IRoomItem>
{
    // TODO: remove-me
    // private static readonly Task<IEnumerable<IRoomItem>> CachedEmptyArray = Task.FromResult(Enumerable.Empty<IRoomItem>());
    // /// <summary>
    // /// This method return EMPTY for obviously reason.
    // /// </summary>
    // /// <returns>Empty array</returns>
    // async ValueTask<IEnumerable<IRoomItem>> IRepositoryBase<RoomItemId, RoomItem>.GetAll()
    // {
    //     return await CachedEmptyArray;
    // }
}