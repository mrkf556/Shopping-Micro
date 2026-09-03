using Discount.Application.Protos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Query
{
    public class GetDiscountByProductIdQuery : IRequest<CouponModel>
    {
        public string ProductId { get; set; }

        public GetDiscountByProductIdQuery(string productId)
        {
            ProductId = productId;
        }
    }

}
