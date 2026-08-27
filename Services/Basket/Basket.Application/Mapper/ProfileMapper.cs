using AutoMapper;
using Basket.Application.Commands.CreateBasket;
using Basket.Application.Responsies;
using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Mapper
{
    public  class ProfileMapper:Profile
    {
        public ProfileMapper()
        {
            CreateMap<ShoppingCartItems, ShopingCartItemResponse>().ReverseMap();
           // CreateMap<ShoppingCart, CreateBasketCommand>().ReverseMap();
            CreateMap<CreateBasketCommand, ShoppingCart>()
     .ForCtorParam(
         "userName",
         opt => opt.MapFrom(src => src.Username))
     .ForCtorParam(
         "id",
         opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<ShoppingCart, ShoppingCartResponse>().ReverseMap();
            CreateMap<ShoppingCartResponse, CreateBasketCommand>().ReverseMap();

        }
    }
}
