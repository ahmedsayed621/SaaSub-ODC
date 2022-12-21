using System.Linq.Expressions;
using System.Collections.Generic;

namespace PricingPlans.API.Data.Base
{
    public interface IEntityBaseRepo<T> where T : class, IEntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
