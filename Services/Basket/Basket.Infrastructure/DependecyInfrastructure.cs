
using Basket.Application;
using Basket.Core.Repositories;
using Basket.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Basket.Infrastructure
{
    public static class DependecyInfrastructure
    {
        public static IServiceCollection AddApplicationInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddScoped<IBasketRepository,BasketRepository>();
            ///
            var redisConnectionString = configuration.GetConnectionString("Redis");

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString!));
            return services;
        }
    }
}
