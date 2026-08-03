using Catalog.Application.Handlers.Products;
using Catalog.Application.Queries.Brands;
using Catalog.Application.Queries.Products;
using Catalog.Application.Queries.Types;
using Catalog.Application.Responses;
using Catalog.Core.CatalogSpecs;
using Catalog.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Catalog.Api.Controllers
{

    public class CatalogController : ApiController
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator) => _mediator = mediator;
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery(id), cancellation));
        }
        [HttpGet("byName/{name}")]
        public async Task<ActionResult<ProductResponse>> GetProductsByName(string name, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetProductByNameQuery(name), cancellation));
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductResponse>>> GetAllProducts([FromQuery] GetAllProductsQuery catalogSpecsParams, CancellationToken cancellation)
        {


            return Ok(await _mediator.Send(catalogSpecsParams, cancellation));

        }
        [HttpGet("brand")]
        public async Task<ActionResult<IEnumerable<BrandResponse>>> GetProductByBrand(CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetAllProductBrandQuery(), cancellation));


        }
        [HttpGet("type")]
        public async Task<ActionResult<IEnumerable<TypeResponse>>> GetProductByType(CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetAllProductTypeQuery(), cancellation));


        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand createProduct, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(createProduct, cancellation));

        }
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand updateProduct, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(updateProduct, cancellation));

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(string id, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new DeleteProductCommand(id), cancellation));

        }






    }
}
