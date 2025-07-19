using Microsoft.Azure.Cosmos;

namespace XBuddy.Application.Repositories
{
    public interface ICosmosRepository
    {
        Task<ItemResponse<T>> Delete<T>(string id, string tenantId);
        Task<T> GetItemById<T>(string id, string tenantId);
        Task<ItemResponse<T>> UpSert<T>(T value, string tenantId, CancellationToken cancellationToken = default);
    }
}
