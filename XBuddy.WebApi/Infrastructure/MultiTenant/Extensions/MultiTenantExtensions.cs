using Microsoft.Extensions.DependencyInjection.Extensions;
using XBuddy.Application.Services;
using XBuddy.WebApi.Infrastructure.Middleware;
using XBuddy.WebApi.Infrastructure.MultiTenant.Options;
using XBuddy.WebApi.Infrastructure.MultiTenant.Resolvers;
using XBuddy.WebApi.Infrastructure.MultiTenant.Services;
using XBuddy.WebApi.Infrastructure.Services;

namespace XBuddy.WebApi.Infrastructure.MultiTenant.Extensions
{
    public static class MultiTenantExtensions
    {
        public static IServiceCollection AddMultiTenancy(this IServiceCollection services, Action<MultiTenancyOptions> options)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<MultiTenantMiddleware>();
            services.AddScoped<IMultiTenantService, MultiTenantService>();
            services.AddScoped<ITenantMappingService, TenantMappingService>();
            services.AddScoped<MultiTenantIdEndPointFilter>();
            var opt = new MultiTenancyOptions();
            options(opt);

            if (opt.InternalUseRouteResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantUrlRouteResolver>());
            }
            if (opt.InternalUseHeaderResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantHeaderResolver>());
            }
            if (opt.InternalUseQueryStringResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantQueryStringResolver>());
            }
            if (opt.InternalUseCookieResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantCookieResolver>());
            }
            if (!opt.AtLeastOneActive)
            {
                throw new Exception("At least one resolver must be active. Use UseCookieResolver, UseHeaderResolver, UseQueryStringResolver, or UseRouteResolver.");
            }
            return services;
        }
        public static IServiceCollection AddMultiTenancy(this IServiceCollection services)
        {
            AddMultiTenancy(services, options =>
            {
                options.UseRouteResolver().
                UseQueryStringResolver().
                UseHeaderResolver().
                UseCookieResolver();
            });

            return services;
        }
        public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder app)
        {
            app.UseMiddleware<MultiTenantMiddleware>();
            return app;
        }
    }
}
