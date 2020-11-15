using ConsoleApp_MongoDz.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_MongoDz.Repository
{
    public class Repository<TEntity> where TEntity : IEntity
    {
        protected readonly IMongoCollection<TEntity> collection;
        public Repository(IMongoDatabase database)
        {
            collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task<ObjectId> InsertAsync (TEntity entity)
        {
            await collection.InsertOneAsync(entity);
            return entity.Id;
        }
        public async Task<long> CheckCollection()
        {
            return await collection.EstimatedDocumentCountAsync();
        }

        public virtual IList<TEntity> Sort(BsonDocument filter, int skip, int limit)
        {
            return null;
        }

        public async virtual Task<IList<OrderGrouping>> ShowReport()
        {
            return null;
        }
    }
}
