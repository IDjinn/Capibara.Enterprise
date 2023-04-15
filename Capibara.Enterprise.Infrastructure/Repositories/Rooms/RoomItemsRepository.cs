using System.Data;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Common;
using Capibara.Enterprise.Core.API.Hotel.Rooms.Items;
using Capibara.Enterprise.Core.API.Util.Attributes;
using Capibara.Enterprise.Core.API.Util.Interfaces;
using Capibara.Enterprise.Infrastructure.API.Database;
using Capibara.Enterprise.Infrastructure.API.Repositories.Rooms;
using Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace Capibara.Enterprise.Infrastructure.Repositories.Rooms;

[Inject(ServiceLifetime.Singleton)]
public class RoomItemsRepository : IRoomItemsRepository
{
    private readonly IDbConnection _connection;
    private readonly ISqlSerializer<IRoomItem> _serializer;

    public RoomItemsRepository(IDbConnectionFactory connectionFactory, ISqlSerializer<IRoomItem> serializer)
    {
        _serializer = serializer;
        _connection = connectionFactory.CreateConnection();
    }

    public async ValueTask<IRoomItem?> GetAsync(RoomItemId id)
    {
        return _serializer.FromDapperDynamicRow(
            await _connection.QueryFirstOrDefaultAsync("select * from room_items where item_id = @Id",
                new { Id = id.Id.ToString() })
        );
    }


    public async ValueTask<int> UpdateAsync(IRoomItem entity)
    {
        throw new NotImplementedException();
    }

    public async ValueTask DeleteAsync(IRoomItem entity)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<IEnumerable<IRoomItem>> GetAllAsync(ChunkId chunk)
    {
        throw new NotImplementedException();
    }
}