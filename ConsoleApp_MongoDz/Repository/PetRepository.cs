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
    public class PetRepository : Repository<Pet>
    {
        public PetRepository(IMongoDatabase database) :base (database)
        {
            collection.Indexes.CreateOne(new CreateIndexModel<Pet>(Builders<Pet>.IndexKeys.Ascending(x => x.RegistrationDate)));
            collection.Indexes.CreateOne(new CreateIndexModel<Pet>(Builders<Pet>.IndexKeys.Ascending(x => x.Type)));
        }

        public override IList<Pet> Sort(BsonDocument filter, int skip, int limit)
        {
            return collection.Find(filter)
                            .SortByDescending(p => p.RegistrationDate)
                            .Skip(skip)
                            .Limit(limit)
                            .ToList();
        }

        public async override Task<IList<OrderGrouping>> ShowReport()
        {
            return await collection
            .Aggregate(new AggregateOptions { AllowDiskUse = true })
            .Group(o => o.Type, (group) => new OrderGrouping  { Type = group.Key, Count = group.Count() }).ToListAsync();
        }
    }
}
