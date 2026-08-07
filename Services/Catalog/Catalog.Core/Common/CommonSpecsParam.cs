using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Common
{
    public
        class CommonSpecsParam
    {
        private const int MaxPageSize = 70;
        public int PageSize { get; set => field = value > MaxPageSize ? MaxPageSize : value; } = 10;
        public int PageIndex { get; set; } = 1;
        public string Sort { get; set; }
        public string Search { get; set; }
    }
}
