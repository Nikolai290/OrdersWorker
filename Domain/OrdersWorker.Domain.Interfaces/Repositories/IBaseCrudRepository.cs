using OrdersWorker.Core.DbEntities;

namespace OrdersWorker.Domain.Interfaces.Repositories;

public interface IBaseCrudRepository<TEntity, TId> where TEntity : BaseDbEntity<TId>
{
    IQueryable<TEntity> GetAllAsync(CancellationToken cancellationToken);
    
    Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken);
    
    Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken);
    
    Task CreateRangeAsync(IEnumerable<TEntity> list, CancellationToken cancellationToken);
    
    Task<TEntity> UpdateAsync(TEntity obj, CancellationToken cancellationToken);
    Task UpdateRangeAsync(IEnumerable<TEntity> list, CancellationToken cancellationToken);
    
    Task DeleteAsync(TId id, CancellationToken cancellationToken);
    
    Task SaveAsync(CancellationToken cancellationToken);
}