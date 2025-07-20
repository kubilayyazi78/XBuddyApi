using XBuddy.WebApi.Infrastructure.EndPoints.RequestHandlers;

namespace XBuddy.WebApi.Infrastructure.EndPoints
{
    public static class RegisterRequestMapping
    {
        public static void RegisterMappings(this WebApplication app)
        {
            FeedEndpoints.RegisterFeedMappings(app);
        }
    }
}
