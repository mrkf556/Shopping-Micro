using Discount.Application.Protos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Application.CQRS.Command
{

    public class DeleteDiscountByNameCommand : IRequest<bool>
    {
        public string ProductName { get; set; }

        public DeleteDiscountByNameCommand(string productName)
        {
            ProductName = productName;
        }
    }
    //public class DeleteDiscountByNameCommand : IRequest<bool>
    //{
    //    public DeleteDiscountRequestByName ProductName { get; set; }

    //    public DeleteDiscountByNameCommand(DeleteDiscountRequestByName productName)
    //    {
    //        ProductName.ProductName = productName.ProductName;
    //    }
    //}
}
