using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //[BsonElement("Created_At")]
        //public DateTime CreatedAt { get; set; } = DateTime.Now;
        //[BsonElement("Updated_At")]

        //public DateTime UpdatedAt { get; set; }
    }
}
