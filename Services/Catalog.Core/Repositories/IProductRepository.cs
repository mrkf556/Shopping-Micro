using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductsById(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByType(string type);
        Task<IEnumerable<Product>> GetProductByTypeId(string typeId);
        Task<IEnumerable<Product>> GetProductByBrand(string brand);
        Task<IEnumerable<Product>> GetProductByBrandId(string brandId);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product product);
        Task<bool> DeleteProduct(string id);
        Task<Product> CreateProduct(Product product);
    }
}
