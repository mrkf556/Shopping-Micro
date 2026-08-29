using Discount.Application.Protos;
using Discount.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Command
{
    public class UpdateDiscountCommand : IRequest<CouponModel>
    {
        public CouponModel CouponModel { get; set; }

        public UpdateDiscountCommand(CouponModel couponModel)
        {
            CouponModel = couponModel;
        }
    }

}
