using Qarc.DataFeed.Core.Domain.SharedKernel;
using System.Linq.Expressions;

namespace Qarc.DataFeed.Core.Application.SharedKernel
{
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task CreateManyAsync(IEnumerable<T> entities);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(string id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task RemoveAsync(string id);
        Task UpdateAsync(T entity);
    }
}
