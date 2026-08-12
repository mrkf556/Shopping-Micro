using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Data.Context
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; set; }
        IMongoCollection<ProductType> Types { get; set; }
        IMongoCollection<ProductBrand> Brands { get; set; }
    }
}
