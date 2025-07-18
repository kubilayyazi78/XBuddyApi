using Microsoft.Azure.Cosmos;
using XBuddy.Infra.Cosmos.Extensions;

namespace XBuddy.Infra.Cosmos.Repositories
{
    public class BaseCosmosRepository(CosmosClient cosmosClient, string dbName, string containerName)
    {
        private readonly Container container = cosmosClient.GetContainer(dbName, containerName);

        public virtual Task<ItemResponse<T>> UpSert<T>(T value, string tenantId, CancellationToken cancellationToken = default)
        {
            return container.UpsertItemAsync(value, new PartitionKey(tenantId), cancellationToken: cancellationToken);
        }

        public virtual Task<ItemResponse<T>> Delete<T>(string id, string tenantId)
        {
            return container.DeleteItemAsync<T>(id, tenantId.ToPartitionKey());
        }
        public virtual async Task<T> GetItemById<T>(string id, string tenantId)
        {
            using var streamResponse = await container.ReadItemStreamAsync(id, tenantId.ToPartitionKey());
            if (streamResponse is { StatusCode: System.Net.HttpStatusCode.OK })
            {
                var cacheModel = cosmosClient.ClientOptions.Serializer.FromStream<T>(streamResponse.Content);
                return cacheModel;
            }
            return default;
        }
    }
}
