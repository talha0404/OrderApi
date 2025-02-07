using OrderApi.Application.Mapping;

namespace OrderApi.Application.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}