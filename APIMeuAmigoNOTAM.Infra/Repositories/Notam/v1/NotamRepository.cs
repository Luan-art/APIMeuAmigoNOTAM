using APIMeuAmigoNOTAM.Domain.Contracts.v1;
using APIMeuAmigoNOTAM.Domain.Entities.v1;
using Infra.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Infra.Repositories.Notam.v1
{
    public class NotamRepository : BaseDbRepository<Domain.Entities.v1.Notam, string>, INotamRepository
    {
        public NotamRepository(IMongoClient client) : base(client)
        {
        }

        public async Task AddAsync(Domain.Entities.v1.Notam entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Domain.Entities.v1.Notam entity)
        {
            var filter = Builders<Domain.Entities.v1.Notam>.Filter.Eq(e => e.Id, entity.Id);
            await Collection.ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = true });
        }

        async Task<Domain.Entities.v1.Notam?> IRepository<Domain.Entities.v1.Notam, string>.GetById(string id)
        {
            var filter = Builders<Domain.Entities.v1.Notam>.Filter.Eq(e => e.Id, id);
            return await Collection.Find(filter).SingleOrDefaultAsync();
        }

        async Task<List<Domain.Entities.v1.Notam>> IRepository<Domain.Entities.v1.Notam, string>.GetAllAsync()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }
    }
}
