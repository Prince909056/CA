using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Repositories;
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entity);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entity);
    Task DeleteAsync(T entity);
    Task DeleteAsyncRange(IEnumerable<T> entity);


    //T GetById(int id);
    //IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
    //Task AddRangeAsync();
    //void Add(T entity);
    //void AddRange(IEnumerable<T> entity);
    //void Update(T entity);
    //void UpdateRange(IEnumerable<T> entity);
    //void Delete(T entity);
    //void DeleteRange(IEnumerable<T> entity);
    //Task<bool> Exists(Expression<Func<T, bool>> predicate);
}
