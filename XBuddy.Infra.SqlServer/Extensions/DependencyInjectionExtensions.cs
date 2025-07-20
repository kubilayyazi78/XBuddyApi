using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XBuddy.Infra.SqlServer.Context;
using XBuddyModels.Helpers;

namespace XBuddy.Infra.SqlServer.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraSqlServices(this IServiceCollection services, string connectionString, GetTenantIdDelegate getTenantIdDelegate)
        {
            services.AddDbContext<TenantMappingContext>((sp, options) =>
            {
                var logger = sp.GetRequiredService<ILogger<TenantMappingContext>>();
                //logger.LogWarning("Using connection string: {ConnectionString}", connectionString);
                options.UseSqlServer(connectionString);
            });

            services.AddDbContext<XBuddyDbContext>((sp, options) =>
            {
                var logger = sp.GetRequiredService<ILogger<XBuddyDbContext>>();
                //logger.LogWarning("Using connection string: {ConnectionString}", connectionString);
                options.UseSqlServer(connectionString);
                // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
            });
            services.AddSingleton(getTenantIdDelegate);

            return services;
        }
    }
}
