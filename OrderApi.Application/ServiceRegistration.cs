using Microsoft.Extensions.DependencyInjection;
using OrderApi.Application.Interfaces;
using OrderApi.Application.Mapping;
using OrderApi.Application.Services;
using OrderApi.Infrastructre;

namespace OrderApi.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register AutoMapper
        // The error occurs because the AddAutoMapper method expects a second argument of type Action<IMapperConfigurationExpression>
        // You need to provide a configuration action for AutoMapper instead of just the MappingProfile type.
        // Here is how to fix it:

        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        // Register Services
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IUserService, UserService>();

        services.AddInfrastructure();

        return services;
    }
}