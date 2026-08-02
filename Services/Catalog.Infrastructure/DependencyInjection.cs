using Catalog.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure
{
    public static class DependencyInjectionInfraStructure
    {
        public static IServiceCollection AddApplicationInfra(this IServiceCollection services)
        {
            services.AddApplication();
            return services;
        }

    }
}
