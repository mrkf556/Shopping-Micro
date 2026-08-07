using Catalog.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.CatalogSpecs
{
    public class CatalogSpecsParams : CommonSpecsParam
    {
        public string BrandId { get; set; }
        public string TypeId { get; set; }
    }
}
