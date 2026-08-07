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
    public class DeleteProductCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public DeleteProductCommand(string id)
        {
            Id = id;
        }
    }
    public class DeleteProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            return await _productRepository.DeleteProduct(request.Id);

        }
    }
}
