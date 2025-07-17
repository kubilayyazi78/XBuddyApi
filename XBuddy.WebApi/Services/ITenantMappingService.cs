
namespace XBuddy.WebApi.Services
{
    public interface ITenantMappingService
    {
        Guid? GetUserByTenantId(string tenantId);
    }
}