namespace Products.API.Helpers;

public static class ConfigMediatR
{
    public static IServiceCollection AddMediatRHandlers(this IServiceCollection services)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        return services;
    }
}
