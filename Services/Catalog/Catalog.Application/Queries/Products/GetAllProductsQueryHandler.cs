using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.CatalogSpecs;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries.Products
{
    public class GetAllProductsQuery : CatalogSpecsParams, IRequest<Pagination<ProductResponse>>
    {

    }
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Pagination<ProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetAllProductsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Pagination<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetProducts(request);
            return _mapper.Map<Pagination<ProductResponse>>(result);
        }
    }
}
