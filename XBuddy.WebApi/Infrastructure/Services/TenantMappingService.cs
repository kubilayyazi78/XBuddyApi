using XBuddy.Application.Services;
using XBuddy.Infra.SqlServer.Context;

namespace XBuddy.WebApi.Infrastructure.Services
{
    public class TenantMappingService : ITenantMappingService
    {
        private TenantMappingContext context;
        private readonly IServiceProvider serviceProvider;
        private Dictionary<string, Guid> map;
        public TenantMappingService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            LoadMap();
        }

        public Guid? GetUserByTenantId(string tenantId)
        {
            return map.TryGetValue(tenantId, out var userId) ? userId : null;
        }
        private void LoadMap()
        {
            using var scope = serviceProvider.CreateScope();
            context = scope.ServiceProvider.GetService<TenantMappingContext>();
            map = context.TenantMappings
                .ToDictionary(x => x.TenantId, x => x.UserId);
        }
    }
}
