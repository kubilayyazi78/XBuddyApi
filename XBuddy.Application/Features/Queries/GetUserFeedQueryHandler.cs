using Mediator;
using Microsoft.EntityFrameworkCore;
using XBuddy.Application.Extensions;
using XBuddy.Application.Services;
using XBuddy.Infra.SqlServer.Context;
using XBuddyModels.Paging;
using XBuddyModels.Queries.Feed;
namespace XBuddy.Application.Features.Queries
{
    public class GetUserFeedQueryHandler : IRequestHandler<GetUserFeedQuery, PagedResponse<GetUserFeedViewModel>>
    {
        private readonly XBuddyDbContext xBuddyDbContext;
        ITenantMappingService tenantMappingService;
        public GetUserFeedQueryHandler(ITenantMappingService tenantMappingService, XBuddyDbContext xBuddyDbContext)
        {
            this.tenantMappingService = tenantMappingService;
            this.xBuddyDbContext = xBuddyDbContext;
        }
        public async ValueTask<PagedResponse<GetUserFeedViewModel>> Handle(GetUserFeedQuery request, CancellationToken cancellationToken)
        {
            var tenantUserId = tenantMappingService.GetUserByTenantId(request.TenantId);

            var followingsFeed = await xBuddyDbContext.Follows
                .Where(f => f.FollowerUserId == tenantUserId)
                .SelectMany(i => i.FollowingUser.Tweets)
                .OrderBy(i => i.CreatedDate)
                .Select(t => new GetUserFeedViewModel
                {
                    Id = t.Id,
                    Content = t.Content,
                    UserId = t.UserId,
                    UserName = t.User.UserName,
                    LikesCount = t.Likes.Count,
                    IsLiked = t.Likes.Any(l => l.UserId == tenantUserId),
                    CreatedAt = t.CreatedDate,
                    ViewCount = t.ViewCount
                }).GetPage(request.PageNumber, request.PageSize);

            return followingsFeed;
        }
    }
}
