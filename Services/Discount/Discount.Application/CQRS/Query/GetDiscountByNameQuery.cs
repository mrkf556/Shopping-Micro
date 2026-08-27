using Discount.Application.Protos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Query
{
    public class GetDiscountByNameQuery : IRequest<CouponModel>
    {
        public string ProductName { get; set; }

        public GetDiscountByNameQuery(string productName)
        {
            ProductName = productName;
        }
    }

}
