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
        Task<bool> DeleteAsync(TId id); 
        Task<TEntity?> GetById(TId id);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllAsync();


    }
}
