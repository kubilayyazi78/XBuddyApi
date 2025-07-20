using XBuddy.Application.Infrastucture.Models.MultiTenant;
using XBuddy.WebApi.Infrastructure.MultiTenant.Services;

namespace XBuddy.WebApi.Infrastructure.Middleware
{
    public class MultiTenantIdEndPointFilter(IMultiTenantService multiTenantService) : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var currentTenantId = multiTenantService.GetCurrentTenantId();
            foreach (var arg in context.Arguments)
            {
                if (arg is IMultiTenant multiTenant)
                {
                    multiTenant.TenantId = currentTenantId;
                }
            }
            return await next(context);
        }
    }
}
