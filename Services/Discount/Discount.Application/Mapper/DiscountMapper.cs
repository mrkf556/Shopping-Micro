using AutoMapper;
using Discount.Application.Protos;
using Discount.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.Mapper
{
    public  class DiscountMapper:Profile
    {
        public DiscountMapper()
        {
            CreateMap<Discounts, CouponModel>().ReverseMap();
        }
    }
}
