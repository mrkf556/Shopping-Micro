using AutoMapper;
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
            CreateMap<ShoppingCartItems, ShoppingCartResponse>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartResponse>().ReverseMap();

        }
    }
}
