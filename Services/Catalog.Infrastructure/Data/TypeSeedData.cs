using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class TypeSeedData
    {
        public static void SeedData(IMongoCollection<ProductType> productTypeCollection)
        {
            var existsCollection = productTypeCollection.Find(x => true).Any();
            if (existsCollection) return;
            var pathJson = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "products.json");
            if (File.Exists(pathJson))
            {
                throw new Exception($"the seed data of the brand did't find:{pathJson}");
            }
            var dataText = File.ReadAllText(pathJson);
            var brands = JsonSerializer.Deserialize<List<ProductType>>(dataText);
            if (brands != null)
            {
                productTypeCollection.InsertMany(brands);
            }
        }
    }
}
