using Discount.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Core.Interfaces
{
    public  interface IDiscountRepository
    {
        Task<Discounts> GetDiscount(string productId);
        Task<Discounts> GetDiscountsByName(string name);
        Task<bool> CreateDiscount(Discounts discounts);
        Task<bool> UpdateDiscount(Discounts discounts);
        Task<bool> DeleteDiscount(string productId);
        Task<bool> DeleteDiscountByName(string name);
      //  Task<Discount> 
    }
}
