using Mediator;
using XBuddy.Application.Features.Base;
using XBuddy.Application.Infrastucture.Models.MultiTenant;
using XBuddyModels.Constants;
using XBuddyModels.Paging;
using XBuddyModels.Queries.Feed;
namespace XBuddy.Application.Features.Queries
{
    public class GetUserFeedQuery : CacheablePagedQuery<GetUserFeedViewModel>
    {
        public override string CacheKey => Constants.CacheKeys.UserFeed;
    }
}
