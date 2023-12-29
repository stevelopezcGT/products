using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;
using Products.Application.Services;
using Products.Data;
using Products.Data.Repositories;
using Products.Domain.Interfaces;

namespace Products.API.Helpers
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion

            #region Services
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IDiscountService, DiscountService>();
            #endregion

            #region Repositories
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion            

            return services;
        }
    }
}
