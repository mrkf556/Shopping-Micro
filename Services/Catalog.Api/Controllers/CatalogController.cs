using Catalog.Application.Queries.Products;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ApiController
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator) => _mediator = mediator;
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery(id), cancellation));
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductsByName(string name, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetProductByNameQuery(name), cancellation));
        }

    }
}
