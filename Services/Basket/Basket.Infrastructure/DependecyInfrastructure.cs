
using Basket.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Infrastructure
{
    public static class DependecyInfrastructure
    {
        public static IServiceCollection AddApplicationInfra(this IServiceCollection services)
        {
            services.AddApplication();
             
            return services;
        }
    }
}
