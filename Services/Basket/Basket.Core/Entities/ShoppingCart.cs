using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Core.Entities
{
    public class ShoppingCart
    {
   

        public string UserName { get; set; }
        public Guid id { get; set; } = Guid.NewGuid();

        public List<ShoppingCartItems> Items { get; set; } = new();
        //دلیل وجود سازنده بدون پارامتر که مپر بتواند با نمونه سازی به اجزای ان دسترسی داشته یاشد برای مقداردهی
        //اگر هم نزاریم خودش میسازد
        //public ShoppingCart()
        //{
            
        //}
        //اگر قانون کسب‌وکار واقعاً باید همیشه رعایت شود، نباید فقط به constructor پارامتردار وابسته باشی، در حالی که constructor خالی هم اجازه ساخت Entity می‌دهد.
        public ShoppingCart(string userName, Guid id)
        {
            if (string.IsNullOrWhiteSpace(userName)&& id == Guid.Empty)
            {
                throw new Exception("Username or id Not must be empty");
            }
            UserName = userName;
            this.id = id;
        }

        public decimal CalculatedOrginalPrice()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }

    }
}
