using XBuddy.Application.Repositories;
using XBuddy.Application.Services;
using XBuddy.Infra.Cosmos.Models;

namespace XBuddy.Infra.Cosmos.Services
{
    public class TenantCacheService(ICacheRepository cacheRepository) : ITenantCacheService
    {
        public async Task<T> GetCache<T>(string tenantId, string key)
        {
            var cacheModel = await cacheRepository.GetItemById<BaseCosmosModel<T>>(key, tenantId);

            return cacheModel is null ? default : cacheModel.Value;
        }

        public async Task SetCache<T>(string tenantId, string key, T value)
        {
            BaseCosmosModel<T> cacheModel = new()
            {
                Id = key,
                TenantId = tenantId,
                Value = value
            };
            await cacheRepository.UpSert(cacheModel, tenantId, default);
        }
    }
}
