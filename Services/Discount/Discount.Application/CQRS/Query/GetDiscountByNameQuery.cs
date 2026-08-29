using Discount.Application.Protos;
using Discount.Core.Entities;
using MediatR;
 

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
