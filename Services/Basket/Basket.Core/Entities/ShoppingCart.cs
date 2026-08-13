using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Core.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public string UserId { get; set; }

        public List<ShoppingCartItems> Items { get; set; } = new();

        public ShoppingCart(string username, string userId)
        {
            UserName = username;
            UserId = userId;
        }

        public decimal CalculatedOrginalPrice()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }

    }
}
