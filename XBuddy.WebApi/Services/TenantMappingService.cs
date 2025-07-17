using XBuddy.Infra.SqlServer.Context;

namespace XBuddy.WebApi.Services
{
    public class TenantMappingService : ITenantMappingService
    {
        private TenantMappingContext context;
        private readonly ServiceProvider serviceProvider;
        private Dictionary<string, Guid> map;
        public TenantMappingService(ServiceProvider serviceProvider)
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
