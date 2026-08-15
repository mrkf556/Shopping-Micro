using AutoMapper;
using Basket.Application.Responsies;
using Basket.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Queries.GetBasket
{
    public class GetBasketByUserNameQuery(string Username):IRequest<ShoppingCartResponse>
    {
        public string Username { get; set; } = Username;

    }
    public class GetBasketByUserNameQueryHandler : IRequestHandler<GetBasketByUserNameQuery, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public GetBasketByUserNameQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<ShoppingCartResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasket(request.Username);
            if (basket == null) {
                return new ShoppingCartResponse(request.Username);
            }
            return _mapper.Map<ShoppingCartResponse>(basket);
        }
    }

}
