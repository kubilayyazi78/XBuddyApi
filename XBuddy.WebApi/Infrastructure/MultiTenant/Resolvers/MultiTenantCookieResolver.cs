namespace XBuddy.WebApi.Infrastructure.MultiTenant.Resolvers
{
    public class MultiTenantCookieResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
    {
        public string Resolve()
        {
            return httpContextAccessor.HttpContext?.Request?.Cookies[IMultiTenantResolver.TenantIdKey];
                   
        }
    }
}
