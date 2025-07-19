using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.DependencyInjection;
using XBuddy.Application.Repositories;
using XBuddy.Application.Services;
using XBuddy.Infra.Cosmos.Repositories;
using XBuddy.Infra.Cosmos.Services;

namespace XBuddy.Infra.Cosmos.Extensions
{
    public static class DependecyInjectionExtensions
    {
        public static IServiceCollection AddInfraCosmosService(this IServiceCollection services, string cosmosConnStr)
        {
            services.AddSingleton(sp =>
            {
                var builder = new CosmosClientBuilder(cosmosConnStr)
                .WithApplicationName("XBuddyApi")
                .WithSerializerOptions(new CosmosSerializationOptions()
                {
                    Indented = true
                })
                .WithThrottlingRetryOptions(TimeSpan.FromSeconds(5), 10);
                return builder.Build();
            });
            services.AddScoped<ITenantCacheService, TenantCacheService>();
            services.AddScoped<ICacheRepository, CacheRepository>();

            return services;
        }
    }
}
