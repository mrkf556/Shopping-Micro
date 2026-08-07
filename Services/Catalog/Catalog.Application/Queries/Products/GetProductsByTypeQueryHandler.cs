using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries.Products
{
    public class GetProductsByTypeQuery : IRequest<IEnumerable<ProductResponse>>
    {
        public string Type { get; set; }
        public GetProductsByTypeQuery(string type)
        {
            Type = type;
        }
    }
    public class GetProductsByTypeQueryHandler : IRequestHandler<GetProductsByTypeQuery, IEnumerable<ProductResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetProductsByTypeQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponse>> Handle(GetProductsByTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetProductByType(request.Type);
            return _mapper.Map<IEnumerable<ProductResponse>>(result);
        }
    }
}
