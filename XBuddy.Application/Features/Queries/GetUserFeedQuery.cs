using Mediator;
using XBuddy.Application.Services;
using XBuddy.Infra.SqlServer.Context;
using XBuddyModels.Queries.Feed;
namespace XBuddy.Application.Features.Queries
{
    public class GetUserFeedQuery:IRequest<GetUserFeedViewModel>
    {

    }
    public class GetUserFeedQueryHandler : IRequestHandler<GetUserFeedQuery, GetUserFeedViewModel>
    {
        private readonly XBuddyDbContext xBuddyDbContext;
        ITenantMappingService tenantMappingService;
        public GetUserFeedQueryHandler(ITenantMappingService tenantMappingService, XBuddyDbContext xBuddyDbContext)
        {
            this.tenantMappingService = tenantMappingService;
            this.xBuddyDbContext = xBuddyDbContext;
        }
        public ValueTask<GetUserFeedViewModel> Handle(GetUserFeedQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
