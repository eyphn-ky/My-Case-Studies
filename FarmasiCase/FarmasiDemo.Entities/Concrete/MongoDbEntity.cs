using FarmasiDemo.Entities.Interface;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.Entities.Concrete
{
    public class MongoDbEntity : IEntity
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
