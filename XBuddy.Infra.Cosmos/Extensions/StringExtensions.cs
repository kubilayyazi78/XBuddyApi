using Microsoft.Azure.Cosmos;

namespace XBuddy.Infra.Cosmos.Extensions
{
    public static class StringExtensions
    {
        public static PartitionKey ToPartitionKey(this string tenantId)
        {
            return new PartitionKey(tenantId);
        }
    }
}
