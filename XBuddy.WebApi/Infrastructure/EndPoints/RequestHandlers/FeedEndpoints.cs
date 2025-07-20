using XBuddy.WebApi.Infrastructure.Middleware;
using XBuddyModels.Helpers;

namespace XBuddy.WebApi.Infrastructure.EndPoints.RequestHandlers
{
    public static class FeedEndpoints
    {
        public static void RegisterFeedMappings(this WebApplication app)
        {
            app.Map("feed".AdjustTenantRoute(), HandleFeed).AddEndpointFilter<MultiTenantIdEndPointFilter>();
        }
        private static async Task<IResult> HandleFeed(HttpContent httpContent)
        {
            return null;
        }
    }
}
