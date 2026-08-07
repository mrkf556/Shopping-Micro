using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Entities
{
    [BsonIgnoreExtraElements]

    public class Product : BaseEntity
    {
        [BsonElement(nameof(Name))]
        public string Name { get; set; }
        public string Summery { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }


        //Relation
        public ProductBrand Brands { get; set; }
        public ProductType Types { get; set; }
    }
}
