using Mediator;
using XBuddy.Application.Infrastucture.Models.Interfaces;
using XBuddy.Application.Services;

namespace XBuddy.Application.Infrastucture.PipelineBehaviours;

public class TenantCachePipelineBehaviour<TReq, TRes>(ITenantCacheService tenantCacheService) : IPipelineBehavior<TReq, TRes>
    where TReq : IRequest<TRes>, ITenantCacheable
    where TRes : class
{

    public async ValueTask<TRes> Handle(TReq message, CancellationToken cancellationToken, MessageHandlerDelegate<TReq, TRes> next)
    {
        if (message.IgnoreCacheRead == false)
        {
            var cachedValue = await tenantCacheService.GetCache<TRes>(message.TenantId, message.CacheKey);

            if (cachedValue != null)
            {
                return cachedValue;
            }
        }
        var response = await next(message, cancellationToken);

        if (message.IgnoreCacheWrite == false && response != null)
        {
            await tenantCacheService.SetCache(message.TenantId, message.CacheKey, response);
        }
        return response;
    }
}
