using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddAutoMapper(typeof(DependencyInjection));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            return services;
        }

    }
}
