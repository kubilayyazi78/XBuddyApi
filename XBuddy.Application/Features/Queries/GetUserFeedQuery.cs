using Mediator;
using XBuddy.Application.Features.Base;
using XBuddy.Application.Infrastucture.Models.MultiTenant;
using XBuddyModels.Paging;
using XBuddyModels.Queries.Feed;
namespace XBuddy.Application.Features.Queries
{
    public class GetUserFeedQuery : BasePagedQuery<PagedResponse<GetUserFeedViewModel>>, IMultiTenant
    {
        public string TenantId { get; set; }
    }
}
