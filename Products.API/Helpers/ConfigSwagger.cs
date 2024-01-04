using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Products.API.Helpers;

public static class ConfigSwagger
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Product Backend",
                Description = "Backend for Product project"
            });

            var xmlDocumentationFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlDocumentationFile));
        });

        return services;
    }
}
