using AutoMapper;
using Discount.Application.CQRS.Query;
using Discount.Application.Protos;
using Discount.Core.Interfaces;
using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Handler.Query
{
    public class GetDiscountByProductIdQueryHandler(
     IDiscountRepository discountRepository,
     IMapper mapper,
     ILogger<GetDiscountByProductIdQueryHandler> logger)
     : IRequestHandler<GetDiscountByProductIdQuery, CouponModel>
    {
        public async Task<CouponModel> Handle(GetDiscountByProductIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await discountRepository.GetDiscount(request.ProductId);
            if (entity == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount not found for {request.ProductId}"));
            logger.LogInformation("Discount ProductName : {productName} , Amount : {amount}", entity.ProductName,
                entity.Amount);
            return mapper.Map<CouponModel>(entity);
        }
    }

}
