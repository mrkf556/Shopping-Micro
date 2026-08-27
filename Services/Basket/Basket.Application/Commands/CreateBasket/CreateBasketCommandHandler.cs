using AutoMapper;
using Basket.Application.Responsies;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Commands.CreateBasket
{

    public class CreateBasketCommand(string username, List<ShoppingCartItems> items) : IRequest<ShoppingCartResponse>
    {
        public string Username { get; set; } = username;
        public List<ShoppingCartItems> Items { get; set; } = items;
    }

    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public CreateBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<ShoppingCartResponse> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            //var shoppingConvert = new ShoppingCart();

            //shoppingConvert.UserName = request.Username;
            //shoppingConvert.Items = request.Items;
            try
            {
                 
                var shoppingConvert = _mapper.Map<ShoppingCart>(request);
               
                await _basketRepository.UpdateBasket(shoppingConvert);
                return _mapper.Map<ShoppingCartResponse>(shoppingConvert);

            }
            catch (Exception ex)
            {
                //ServiceResult استفاده کنیم 
                return _mapper.Map<ShoppingCartResponse>(request);
            }

        }
    }
}
