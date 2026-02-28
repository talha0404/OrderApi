using Microsoft.Extensions.DependencyInjection;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Repositories;

namespace OrderApi.Infrastructre;

public static class ServiceRegistration
{
    //NOTE: We don't need to return but added for chaining in need
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}