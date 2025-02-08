using OrderApi.Application.Interfaces;
using OrderApi.Application.Mapping;
using OrderApi.Application.Services;

namespace OrderApi.Application.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));
        // Register Services
        services.AddScoped(typeof(IBaseService<>), typeof(BaseService<,>));

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}