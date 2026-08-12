using Catalog.Application;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Data.Context;
using Catalog.Infrastructure.Repositories;
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
            services.AddSingleton<ICatalogContext, CatalogContext>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

    }
}
