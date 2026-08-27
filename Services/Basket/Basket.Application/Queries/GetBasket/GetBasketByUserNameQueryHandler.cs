using AutoMapper;
using Basket.Application.Responsies;
using Basket.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Queries.GetBasket
{
    public class GetBasketByUserNameQuery :IRequest<ShoppingCartResponse>
    {
        public string Username;
        public GetBasketByUserNameQuery(string Username)
        {
            this.Username= Username;
        }

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
                //اگر در dto ان سازنده نداشتیم به شکل زیر باید عمل میکردیم
                //if (basket == null)
                //{
                //    return new ShoppingCartResponse
                //    {
                //        UserName = request.Username
                //    };
                //}
                return new ShoppingCartResponse(request.Username);
            }
            return _mapper.Map<ShoppingCartResponse>(basket);
        }
    }

}
