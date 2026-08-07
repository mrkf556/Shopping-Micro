using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public readonly ICatalogContext _context;

        public BrandRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductBrand>> GetProductBrands()
        {
            return await _context.Brands.Find(x => true).ToListAsync();
        }
    }
}
