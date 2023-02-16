using System.Linq.Expressions;

namespace UserManagement.Domain.RepositoryInterfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task SaveAsync();
    }
}
