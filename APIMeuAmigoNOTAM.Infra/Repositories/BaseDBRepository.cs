using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class BaseDbRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        private const string DatabaseName = "5by5_Notam";
        private readonly IMongoClient _client;
        protected readonly IMongoCollection<TEntity> Collection;

        public BaseDbRepository(IMongoClient client)
        {
            _client = client;
            Collection = _client.GetDatabase(DatabaseName).GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id);
            await Collection.ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = true });
        }

        public async Task DeleteAsync(TId id)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<TEntity?> GetById(TId id)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var count = await Collection.CountDocumentsAsync(predicate);
            return count > 0;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }
    }
}
