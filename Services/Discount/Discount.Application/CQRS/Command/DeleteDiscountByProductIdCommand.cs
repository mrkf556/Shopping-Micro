using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Command
{
    public class DeleteDiscountByProductIdCommand : IRequest<bool>
    {
        public string ProductId { get; set; }

        public DeleteDiscountByProductIdCommand(string productId)
        {
            ProductId = productId;
        }
    }

}
