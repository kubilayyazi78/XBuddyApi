using Mediator;
using Microsoft.AspNetCore.Mvc;
using XBuddy.Application.Features.Queries;
using XBuddy.WebApi.Infrastructure.Middleware;
using XBuddyModels.Helpers;

namespace XBuddy.WebApi.Infrastructure.EndPoints.RequestHandlers
{
    public static class FeedEndpoints
    {
        public static void RegisterFeedMappings(this WebApplication app)
        {
            app.MapGet("feed".AdjustTenantRoute(), HandleFeed).AddEndpointFilter<MultiTenantIdEndPointFilter>();
        }
        private static async Task<IResult> HandleFeed([FromServices] IMediator mediator,
            [AsParameters] GetUserFeedQuery query)
        {
            var res = await mediator.Send(query);
            //query.TenantId = multitenantservice.GetCurrentTenantId();
            return Results.Ok(res);
        }
    }
}
