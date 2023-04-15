namespace Capibara.Enterprise.Infrastructure.API.Repositories;

public interface IRepositoryBase<in TId, TEntity>
    where TId : struct
{
    public ValueTask<TEntity?> GetAsync(TId id);
    public ValueTask<int> UpdateAsync(TEntity entity);
    public ValueTask DeleteAsync(TEntity entity);
}