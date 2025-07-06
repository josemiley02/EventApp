using System.Linq.Expressions;

namespace EventApp.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllFilteredAsync(params Expression<Func<T, bool>>[] filters);
    Task<T> GetByIdAsync(string id);
    Task AddAsync(T entity);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
}
