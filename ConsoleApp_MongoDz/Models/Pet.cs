using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_MongoDz.Models
{
    public class Pet : IEntity
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        public Pet() { Owner = new Owner(); }
        [BsonRequired]
        public string Nickname { get; set; }
        [BsonRequired]
        public string Type { get; set; }
        [BsonRequired]
        public DateTime RegistrationDate { get; set; }
        [BsonRequired]
        public Owner Owner { get; set; }
    }
}
