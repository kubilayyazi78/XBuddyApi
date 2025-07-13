namespace XBuddy.WebApi.Infrastructure.MultiTenant.Resolvers
{
    public class MultiTenantHeaderResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
    {
        public string Resolve()
        {
            return httpContextAccessor.HttpContext?.Request?.Headers[IMultiTenantResolver.TenantIdKey];
                   
        }
    }
}
