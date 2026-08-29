using AutoMapper;
using Discount.Application.CQRS.Command;
using Discount.Application.Protos;
using Discount.Core.Entities;
using Discount.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Handler.Command
{
    public class UpdateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper)
     : IRequestHandler<UpdateDiscountCommand, CouponModel>
    {
        public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = mapper.Map<Discounts>(request.CouponModel);
            await discountRepository.UpdateDiscount(coupon);
            return request.CouponModel;
        }
    }

}
