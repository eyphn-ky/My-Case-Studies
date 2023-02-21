using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.Entities.Interface
{
    public interface IEntity      
    {
        ObjectId Id { get; }
        DateTime CreatedAt { get; set; }
    }
}
