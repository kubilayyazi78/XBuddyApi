using Microsoft.Azure.Cosmos;
using XBuddy.Application.Repositories;
using XBuddyModels.Constants;

namespace XBuddy.Infra.Cosmos.Repositories
{
    public class CacheRepository(CosmosClient cosmosClient):BaseCosmosRepository(cosmosClient,CosmosConstants.CacheDbName,CosmosConstants.FeedCacheContainerName),ICacheRepository
    {

    }
}
