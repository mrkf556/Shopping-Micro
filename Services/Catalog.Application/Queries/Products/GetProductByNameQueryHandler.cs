using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Queries.Products
{
    public class GetProductByNameQuery : IRequest<ProductResponse>
    {
        public string Name { get; set; }
        public GetProductByNameQuery(string name)
        {
            Name = name;
        }

    }
    public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, ProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetProductByNameQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetProductByName(request.Name);
            if (result == null)
            {
                throw new Exception($"Product Id Not Found:{request.Name}");
            }
            return _mapper.Map<ProductResponse>(result);

        }
    }
}
