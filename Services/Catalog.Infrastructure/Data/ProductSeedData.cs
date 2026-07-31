using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class ProductSeedData
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            var existsCollection = productCollection.Find(x => true).Any();
            if (existsCollection) return;
            var pathJson = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "products.json");
            if (File.Exists(pathJson))
            {
                throw new Exception($"the seed data of the brand did't find:{pathJson}");
            }
            var dataText = File.ReadAllText(pathJson);
            var brands = JsonSerializer.Deserialize<List<Product>>(dataText);
            if (brands != null)
            {
                productCollection.InsertMany(brands);
            }
        }
    }
}
