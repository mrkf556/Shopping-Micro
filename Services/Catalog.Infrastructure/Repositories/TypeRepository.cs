using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        public Task<IEnumerable<ProductType>> GetProductTypes()
        {
            throw new NotImplementedException();
        }
    }
}
