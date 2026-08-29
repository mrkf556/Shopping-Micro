using AutoMapper;
using Discount.Application.CQRS.Query;
using Discount.Application.Protos;
using Discount.Core.Entities;
using Discount.Core.Interfaces;
using Grpc.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Handler.Query
{
    public class GetDiscountByNameQueryHandler(IDiscountRepository discountRepository, IMapper mapper) : IRequestHandler<GetDiscountByNameQuery, CouponModel>
    {
        public async Task<CouponModel> Handle(GetDiscountByNameQuery request, CancellationToken cancellationToken)
        {
            var entity = await discountRepository.GetDiscountsByName(request.ProductName);
            if (entity == null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount not found for {request.ProductName}"));
            return mapper.Map<CouponModel>(entity);
        }
    }

}
