using FluentValidation;
using Products.Application;
using Products.Application.Abstractions.Behaviours;

namespace Products.API.Helpers;

public static class ConfigMediatR
{
    public static IServiceCollection AddMediatRHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(ApplicationAssemblyReference.Assembly);
        return services;
    }
}
