using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries.Products
{
    public class GetProductByBrandQuery : IRequest<IEnumerable<ProductResponse>>
    {
        public string Brand { get; set; }
        public GetProductByBrandQuery(string brand)
        {
            Brand = brand;
        }
    }
    public class GetProductByBrandQueryHandler : IRequestHandler<GetProductByBrandQuery, IEnumerable<ProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetProductByBrandQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponse>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetProductByBrand(request.Brand);
            return _mapper.Map<IEnumerable<ProductResponse>>(result);
        }
    }
}
