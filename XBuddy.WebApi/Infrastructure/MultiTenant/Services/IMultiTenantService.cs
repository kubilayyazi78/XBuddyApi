namespace XBuddy.WebApi.Infrastructure.MultiTenant.Services
{
    public interface IMultiTenantService
    {
        string GetCurrentTenantId();
        string SetCurrentTenantId(string tenantId);
    }
}