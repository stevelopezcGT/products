﻿using Microsoft.EntityFrameworkCore;
using Products.Data;

namespace Products.API.Helpers;

public static class ConfigDataSource
{
    public static IServiceCollection AddDataSource(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductsDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    public static void RunMigrations(IApplicationBuilder app) 
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var dbContext = services.GetRequiredService<ProductsDBContext>();
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
