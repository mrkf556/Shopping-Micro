using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; set; }
        public IMongoCollection<ProductType> Types { get; set; }
        public IMongoCollection<ProductBrand> Brands { get; set; }
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseConnection:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseConnection:DatabaseName"));

            //get of all collection
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseConnection:CollectionName"));
            Types = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseConnection:TypesCollection"));
            Brands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseConnection:BrandsCollection"));
            ///seed data
            BrandSeedData.SeedData(Brands);
            ProductSeedData.SeedData(Products);
            TypeSeedData.SeedData(Types);

        }


    }
}
