using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Responsies
{
    public class ShoppingCartResponse
    {
   

        public string? UserName { get; set; }
        public Guid id { get; set; }  

        public List<ShoppingCartItems> Items { get; set; } = new();
      

        public ShoppingCartResponse(string userName )
        {
            UserName = userName;
         
        }
        public decimal CalculatedOrginalPrice()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }

    }
}
