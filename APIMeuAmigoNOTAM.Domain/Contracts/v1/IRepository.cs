using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Contracts.v1
{
    public interface IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TId id);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllAsync();
    }
}
