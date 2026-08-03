using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;


namespace Catalog.Application.Handlers.Products
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        public string Name { get; set; }
        public string Summery { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }


        public ProductBrand Brands { get; set; }
        public ProductType Types { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {

        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Product>(request);
            var result = await _productRepository.CreateProduct(entity);
            return _mapper.Map<ProductResponse>(result);

        }
    }
}
