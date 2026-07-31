using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Handlers.Products
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Summery { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }


        public ProductBrand Brands { get; set; }
        public ProductType Types { get; set; }
    }
    public class UpdaterProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public UpdaterProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(request);
            return await _productRepository.UpdateProduct(entity);

        }
    }
}
