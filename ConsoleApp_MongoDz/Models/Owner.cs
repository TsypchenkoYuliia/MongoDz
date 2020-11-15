using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_MongoDz.Models
{
    public class Owner
    {
        public string Name {get; set;}
        [BsonRequired]
        public string Phone { get; set; }
    }
}
