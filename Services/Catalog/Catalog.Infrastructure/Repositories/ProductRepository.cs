using Catalog.Core.CatalogSpecs;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ICatalogContext _context;
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            return await DeleteProduct(product.Id);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var delete = await _context.Products.DeleteOneAsync(x => x.Id == id);
            return delete.IsAcknowledged;

        }

        public async Task<IEnumerable<Product>> GetProductByBrand(string brand)
        {
            return await _context.Products.Find(x => x.Brands.Name == brand).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByBrandId(string brandId)
        {
            return await _context.Products.Find(x => x.Brands.Id == brandId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _context.Products.Find(x => x.Types.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByType(string type)
        {
            return await _context.Products.Find(x => x.Types.Name == type).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByTypeId(string typeId)
        {
            return await _context.Products.Find(x => x.Types.Id == typeId).ToListAsync();
        }

        public async Task<Pagination<Product>> GetProducts(CatalogSpecsParams catalogSpecsParams)
        {
            //mongo filter
            var builder = Builders<Product>.Filter;
            var filter = builder.Empty;
            if (!string.IsNullOrEmpty(catalogSpecsParams.Search))
            {
                var searchFilter = builder.Where(x => x.Name.Contains(catalogSpecsParams.Search));
                filter &= searchFilter;

            }
            if (!string.IsNullOrEmpty(catalogSpecsParams.BrandId))
            {
                var brandFilter = builder.Eq(x => x.Brands.Id, catalogSpecsParams.BrandId);
                filter &= brandFilter;
            }
            if (!string.IsNullOrEmpty(catalogSpecsParams.TypeId))
            {
                var typeFilter = builder.Eq(x => x.Types.Id, catalogSpecsParams.TypeId);
                filter &= typeFilter;
            }
            var totalItem = await _context.Products.CountDocumentsAsync(filter);
            var sort = Builders<Product>.Sort.Ascending(x => x.Name);
            if (!string.IsNullOrEmpty(catalogSpecsParams.Sort))
            {
                sort = catalogSpecsParams.Sort switch
                {
                    "priceAsc" => Builders<Product>.Sort.Ascending(x => x.Price),
                    "priceDesc" => Builders<Product>.Sort.Descending(x => x.Price),
                    _ => Builders<Product>.Sort.Ascending(y => y.Name),
                };
            }
            var data = await _context.Products
                .Find(filter)
                .Sort(sort)
                .Skip(catalogSpecsParams.PageSize * (catalogSpecsParams.PageIndex - 1))
                .Limit(catalogSpecsParams.PageSize)
                .ToListAsync();
            return new Pagination<Product>(catalogSpecsParams.PageIndex, catalogSpecsParams.PageSize, (int)totalItem, data);
        }

        public async Task<Product> GetProductsById(string id)
        {
            return await _context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var result = await _context.Products.ReplaceOneAsync(x => x.Id == product.Id, product);
            return result.IsAcknowledged && result.ModifiedCount > 0;

        }
    }
}
