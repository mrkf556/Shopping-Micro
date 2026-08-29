using Discount.Application.CQRS.Command;
using Discount.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Handler.Command
{
    public class DeleteDiscountByNameCommandHandler(IDiscountRepository discountRepository)
      : IRequestHandler<DeleteDiscountByNameCommand, bool>
    {
        public async Task<bool> Handle(DeleteDiscountByNameCommand request, CancellationToken cancellationToken)
        {
            return await discountRepository.DeleteDiscountByName(request.ProductName);
        }
    }

}
