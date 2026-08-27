using Basket.Core.Entities;
using Basket.Core.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Basket.Infrastructure.Services
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IConnectionMultiplexer _redis;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        public async Task DeleteBasket(string username)
        {
            var db = _redis.GetDatabase();

            var key = $"basket:{username}";

            await db.KeyDeleteAsync(key);
        }

        public async Task<ShoppingCart> GetBasket(string username)
        {
            var db = _redis.GetDatabase();

            var key = $"basket:{username}";
            var value = await db.StringGetAsync(key);

            if (value.IsNullOrEmpty)
                return null;

            return JsonSerializer.Deserialize<ShoppingCart>(value.ToString());
        }

     

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart cart)
        {

            var db = _redis.GetDatabase();

            var key = $"basket:{cart.UserName}";

            var value = JsonSerializer.Serialize(cart);

            await db.StringSetAsync(key, value, TimeSpan.FromHours(2));

             return await  GetBasket(cart.UserName);
        }
    }
}
