using AutoMapper;
using Discount.Application.CQRS.Command;
using Discount.Application.Protos;
using Discount.Core.Entities;
using Discount.Core.Interfaces;
using Grpc.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Handler.Command
{
    public class CreateDiscountCommandHandler(IDiscountRepository discountRepository,IMapper mapper) : IRequestHandler<CreateDiscountCommand, CouponModel>
    {
        public async  Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = mapper.Map<Discounts>(request);
            if ( await discountRepository.CreateDiscount(discount))
            {
                return request.CouponModel;
            }
            throw new RpcException(new Status(StatusCode.Unknown, "I didn't able to create a new entity for discount"));
        }
    }
}
