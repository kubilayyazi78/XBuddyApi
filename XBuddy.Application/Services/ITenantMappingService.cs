
namespace XBuddy.Application.Services
{
    public interface ITenantMappingService
    {
        Guid? GetUserByTenantId(string tenantId);
    }
}