namespace XBuddy.Application.Services
{
    public interface ITenantCacheService
    {
        Task SetCache<T>(string tenantId, string key, T value);
        Task<T> GetCache<T>(string tenantId, string key);
    }
}
