using Dapper;
using Discount.Core.Entities;
using Discount.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Discount.Infrastructure.Services
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly string _connectionValue;
        public DiscountRepository(IConfiguration configuration) 
        {
            _connectionValue = configuration["DatabaseSettings:ConnectionString"] ?? 
                throw new InvalidOperationException("Database connection string is not configured."); 
        }
        public async  Task<bool> CreateDiscount(Discounts discounts)
        {
            await using var connection = new NpgsqlConnection(_connectionValue);
            const string sql =
                "INSERT INTO Discounts (ProductName, ProductId, Description, Amount) VALUES (@ProductName, @ProductId, @Description, @Amount)";
            var parameters = new { discounts.ProductName, discounts.ProductId, discounts.Description, discounts.Amount };
            var affected = await connection.ExecuteAsync(sql, parameters);
            return affected > 0;

        }

        public async  Task<bool> DeleteDiscount(string productId)
        {
            await using var connection = new NpgsqlConnection(_connectionValue);
            const string sql = "DELETE FROM Discounts WHERE ProductId=@ProductId";
            var affected = await connection.ExecuteAsync(sql, new { ProductId = productId });
            return affected > 0;

        }

        public async Task<bool> DeleteDiscountByName(string name)
        {
            await using var connection = new NpgsqlConnection(_connectionValue);
            const string sql = "DELETE FROM Discounts WHERE ProductName=@ProductName";
            var affected = await connection.ExecuteAsync(sql, new { ProductName = name });
            return affected > 0;

        }

        public async  Task<Discounts> GetDiscount(string productId)
        {
            await using var connection = new NpgsqlConnection(_connectionValue);
            const string sql = "SELECT * FROM Discounts WHERE ProductId = @ProductId";
            var coupon = await connection.QueryFirstOrDefaultAsync<Discounts>(sql, new { ProductId = productId });
            return coupon ?? new Discounts()
            {
                Amount = 0,
                Description = "",
                Id = 0,
                ProductId = "",
                ProductName = ""
            };

        }

        public async  Task<Discounts> GetDiscountsByName(string name)
        {
            await using var connection = new NpgsqlConnection(_connectionValue);
            const string sql = "SELECT * FROM Discounts WHERE ProductName = @ProductName";
            var coupon = await connection.QueryFirstOrDefaultAsync<Discounts>(sql, new { ProductName = name  });
            return coupon ?? new Discounts()
            {
                Amount = 0,
                Description = "",
                Id = 0,
                ProductId = "",
                ProductName = ""
            };

        }

        public async  Task<bool> UpdateDiscount(Discounts discounts)
        {
            await using var connection = new NpgsqlConnection(_connectionValue);
            const string sql =
                "UPDATE Discounts SET ProductName=@ProductName, ProductId=@ProductId, Description=@Description, Amount=@Amount WHERE Id=@Id";
            var parameters = new { discounts.ProductName, discounts.ProductId, discounts.Description, discounts.Amount, discounts.Id };
            var affected = await connection.ExecuteAsync(sql, parameters);
            return affected > 0;

        }
    }
}
