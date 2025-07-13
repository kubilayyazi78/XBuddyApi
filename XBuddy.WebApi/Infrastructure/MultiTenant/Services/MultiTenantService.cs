namespace XBuddy.WebApi.Infrastructure.MultiTenant.Services
{
    public class MultiTenantService : IMultiTenantService
    {
        private string tenantId;
        public string GetCurrentTenantId() => tenantId;
        public string SetCurrentTenantId(string tenantId) => this.tenantId = tenantId;

        // TODO: GetUserId -> Guid
    }
}
