using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        public Task<bool> DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByBrand(string brand)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByBrandId(string brandId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByType(string type)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByTypeId(string typeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductsById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
