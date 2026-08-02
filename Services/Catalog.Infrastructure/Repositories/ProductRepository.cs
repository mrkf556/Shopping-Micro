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
            await  _context.Products.InsertOneAsync(product);
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

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(x => true).ToListAsync();
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
