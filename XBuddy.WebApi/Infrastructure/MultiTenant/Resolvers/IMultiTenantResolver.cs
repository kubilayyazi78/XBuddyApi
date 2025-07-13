using XBuddyModels.Constants;

namespace XBuddy.WebApi.Infrastructure.MultiTenant.Resolvers
{
    public interface IMultiTenantResolver
    {
        public static string TenantIdKey => MultiTenantConstants.TenantId;
        string Resolve();
    }
}
