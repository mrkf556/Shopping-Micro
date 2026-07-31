using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class BrandSeedData
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            var existsCollection = brandCollection.Find(x => true).Any();
            if (existsCollection) return;
            var pathJson = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "brands.json");
            if (!File.Exists(pathJson))
            {
                throw new Exception($"the seed data of the brand did't find:{pathJson}");
            }
            var dataText = File.ReadAllText(pathJson);
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(dataText);
            if (brands != null)
            {
                brandCollection.InsertMany(brands);
            }
        }

    }
}
