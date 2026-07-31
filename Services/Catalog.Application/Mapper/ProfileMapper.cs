using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<ProductBrand, BrandResponse>().ReverseMap();
            CreateMap<ProductType, TypeResponse>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
        }
    }
}
