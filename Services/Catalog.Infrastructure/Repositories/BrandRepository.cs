using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Repositories
{
    internal class BrandRepository : IBrandRepository
    {
        public Task<IEnumerable<ProductBrand>> GetProductBrands()
        {
            throw new NotImplementedException();
        }
    }
}
