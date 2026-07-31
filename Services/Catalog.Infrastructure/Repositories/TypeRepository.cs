using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        public readonly ICatalogContext _context;
        public TypeRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            return await _context.Types.Find(x => true).ToListAsync();
        }
    }
}
