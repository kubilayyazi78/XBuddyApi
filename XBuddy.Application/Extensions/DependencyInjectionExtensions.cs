using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace XBuddy.Application.Extensions;
public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediator(opt =>
        {
            opt.ServiceLifetime = ServiceLifetime.Scoped;
        });
        services.AddMapster();
        return services;
    }
}
