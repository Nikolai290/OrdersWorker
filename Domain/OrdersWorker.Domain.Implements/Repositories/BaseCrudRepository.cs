using Microsoft.EntityFrameworkCore;
using OrdersWorker.Core.DbEntities;
using OrdersWorker.Domain.Interfaces.Repositories;

namespace OrdersWorker.Domain.Implements.Repositories;

public class BaseCrudRepository<TEntity, TId> : IBaseCrudRepository<TEntity, TId> where TEntity : BaseDbEntity<TId>
{
    protected readonly MsSqlContext _msSqlContext;

    public BaseCrudRepository(MsSqlContext msSqlContext)
    {
        _msSqlContext = msSqlContext;
    }

    public IQueryable<TEntity> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = _msSqlContext.Set<TEntity>();
        return result;
    }

    public Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken)
    {
        return _msSqlContext.Set<TEntity>().SingleAsync(item => item.Id.Equals(id), cancellationToken);
    }

    public async Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        var result = await _msSqlContext.Set<TEntity>().AddAsync(obj, cancellationToken);
        await SaveAsync(cancellationToken);
        return result.Entity;
    }

    public async Task CreateRangeAsync(IEnumerable<TEntity> list, CancellationToken cancellationToken)
    {
        await _msSqlContext.Set<TEntity>().AddRangeAsync(list, cancellationToken);
        await SaveAsync(cancellationToken);
    }

    public async Task<TEntity> UpdateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        var result = _msSqlContext.Set<TEntity>().Update(obj).Entity;
        await SaveAsync(cancellationToken);
        return result;
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> list, CancellationToken cancellationToken)
    {
        _msSqlContext.Set<TEntity>().UpdateRange(list);
        await SaveAsync(cancellationToken);
    }

    public async Task DeleteAsync(TId id, CancellationToken cancellationToken)
    {
        var obj = await GetAsync(id, cancellationToken);
        _msSqlContext.Set<TEntity>().Remove(obj);
        await SaveAsync(cancellationToken);
    }

    public Task SaveAsync(CancellationToken cancellationToken)
    {
        return _msSqlContext.SaveChangesAsync(cancellationToken);
    }
}