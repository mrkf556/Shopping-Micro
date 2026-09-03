using Discount.Application.CQRS.Command;
using Discount.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Handler.Command
{
    public class DeleteDiscountByProductIdCommandHandler(IDiscountRepository discountRepository)
      : IRequestHandler<DeleteDiscountByProductIdCommand, bool>
    {
        public async Task<bool> Handle(DeleteDiscountByProductIdCommand request, CancellationToken cancellationToken)
        {
            return await discountRepository.DeleteDiscount(request.ProductId);
        }
    }

}
