using XBuddy.Application.Services;

namespace XBuddy.WebApi.Infrastructure.MultiTenant.Services
{
    public class MultiTenantService : IMultiTenantService
    {
        private string tenantId;
        private readonly ITenantMappingService tenantMappingService;

        public MultiTenantService(ITenantMappingService tenantMappingService)
        {
            this.tenantMappingService = tenantMappingService;
        }

        public string GetCurrentTenantId() => tenantId;
        public string SetCurrentTenantId(string tenantId) => this.tenantId = tenantId;

        public Guid? GetUserId() => tenantMappingService.GetUserByTenantId(tenantId);
    }
}
