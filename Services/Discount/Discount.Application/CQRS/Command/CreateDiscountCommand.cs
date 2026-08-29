using Discount.Application.Protos;
using Discount.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Command
{
    public class CreateDiscountCommand :IRequest<CouponModel>
    {
     

        public CouponModel CouponModel { get; set; }
        public CreateDiscountCommand(CouponModel couponModel)
        {
            CouponModel = couponModel;
        }

    }
}
