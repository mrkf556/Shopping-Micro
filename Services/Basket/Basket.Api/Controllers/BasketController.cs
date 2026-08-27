using Basket.Application.Commands.CreateBasket;
using Basket.Application.Commands.DeleteBasket;
using Basket.Application.Queries.GetBasket;
using Basket.Application.Responsies;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
     
    public class BasketController : ApiController
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult> GetBasketByUserName(string username,CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(username)) {

                var result = await _mediator.Send(new GetBasketByUserNameQuery(username), cancellationToken);
                return  Ok(result);
            }
            return BadRequest(username);
        }
        [HttpPost]
        public async Task<ActionResult<ShoppingCartResponse>> CreateBasket([FromBody] CreateBasketCommand request,CancellationToken cancellationToken)
        {
            if (request!=null) {
                var result = await _mediator.Send( request, cancellationToken);
                return Ok(result);
            }
            return BadRequest(request);
        }

        [HttpDelete("{username}")]
        public async Task<ActionResult<bool>> DeleteBasket(string username,CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                var result = await _mediator.Send(new DeleteBasketCommand(username), cancellationToken) ;
            }
            return BadRequest(username);
        }


    }
}
 