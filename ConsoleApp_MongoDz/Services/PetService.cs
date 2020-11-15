using ConsoleApp_MongoDz.Models;
using ConsoleApp_MongoDz.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_MongoDz.Services
{
    public class PetService 
    {
        Repository<Pet> _repository;
        public PetService(IMongoDatabase database) 
        { 
            _repository = new PetRepository(database); 
        }
        public async Task<ObjectId> AddAsync(Pet obj)
        {
            return await _repository.InsertAsync(obj);
        }
        public async Task<long> CheckCollection()
        {
            return await _repository.CheckCollection();
        }

        public IList<Pet> ShowPage(BsonDocument filter, int skip, int limit) 
        {
            return _repository.Sort(filter, skip, limit);
        }
        public async Task<IList<OrderGrouping>> ShowReport()
        {
            return await _repository.ShowReport();
        }

        
    }
}
