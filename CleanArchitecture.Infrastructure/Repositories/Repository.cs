using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;
public class Repository<T> : IRepository<T> where T : class
{
    private readonly StrideMemoDbContext _strideMemoDbContext;

    public Repository(StrideMemoDbContext strideMemoDbContext)
    {
        _strideMemoDbContext = strideMemoDbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        var data = await _strideMemoDbContext.Set<T>().AddAsync(entity);
        _strideMemoDbContext.SaveChanges();
        return data.Entity;
    }

    public async Task AddRangeAsync(IEnumerable<T> entity)
    {
        await _strideMemoDbContext.Set<T>().AddRangeAsync(entity);
        _strideMemoDbContext.SaveChanges();
    }

    public async Task DeleteAsync(T entity)
    {
        await Task.Run(() =>
        {
            _strideMemoDbContext.Set<T>().Remove(entity);
            _strideMemoDbContext.SaveChanges();
        });
    }

    public async Task DeleteAsyncRange(IEnumerable<T> entity)
    {
        await Task.Run(() =>
        {
            _strideMemoDbContext.Set<T>().RemoveRange(entity);
            _strideMemoDbContext.SaveChanges();
        });
    }

    public async Task<IEnumerable<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate = null)
    {
        if (predicate == null)
        {
            return await _strideMemoDbContext.Set<T>().ToListAsync();
        }
        else
        {
            return await _strideMemoDbContext.Set<T>().Where(predicate).ToListAsync();
        }
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _strideMemoDbContext.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        await Task.Run(() =>
        {
            _strideMemoDbContext.ChangeTracker.Clear();
            _strideMemoDbContext.Entry(entity).State = EntityState.Modified;
            _strideMemoDbContext.Set<T>().Update(entity);
            _strideMemoDbContext.SaveChanges();
        });
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entity)
    {
        await Task.Run(() =>
        {
            _strideMemoDbContext.ChangeTracker.Clear();
            _strideMemoDbContext.Entry(entity).State = EntityState.Modified;
            _strideMemoDbContext.Set<T>().UpdateRange(entity);
            _strideMemoDbContext.SaveChanges();
        });
    }
}
