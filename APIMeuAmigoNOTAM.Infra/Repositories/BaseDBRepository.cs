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

        public async Task<bool> DeleteAsync(TId id)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            var result = await Collection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;   
        }

        public async Task<TEntity?> GetById(TId id)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }
    }
}
