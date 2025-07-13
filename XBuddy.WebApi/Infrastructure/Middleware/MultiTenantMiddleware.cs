
using XBuddy.WebApi.Infrastructure.MultiTenant.Resolvers;
using XBuddy.WebApi.Infrastructure.MultiTenant.Services;

namespace XBuddy.WebApi.Infrastructure.Middleware
{
    public class MultiTenantMiddleware(IEnumerable<IMultiTenantResolver> resolvers) : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var multiTenantService = context.RequestServices.GetRequiredService<IMultiTenantService>();
            foreach (var resolver in resolvers)
            {
                var tenantId = resolver.Resolve();
                if (string.IsNullOrEmpty(tenantId))
                {
                    continue;
                }
                multiTenantService.SetCurrentTenantId(tenantId);

                return next(context);
            }
            context .Response.StatusCode = StatusCodes.Status400BadRequest;
            return context.Response.WriteAsync("Tenant ID not found in request.");
        }
    }
}
