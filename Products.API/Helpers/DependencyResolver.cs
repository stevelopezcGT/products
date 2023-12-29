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
            services.AddDbContext<ProductsDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            #region Repositories
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion

            #region Services
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IStatusService, StatusService>();

            #endregion

            #region Repositories
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            #endregion            

            return services;
        }
    }
}
