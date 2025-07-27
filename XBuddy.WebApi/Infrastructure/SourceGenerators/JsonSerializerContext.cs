using System.Text.Json.Serialization;
using XBuddyModels.Paging;
using XBuddyModels.Queries.Feed;

namespace XBuddy.WebApi.Infrastructure.SourceGenerators;

[JsonSerializable(typeof(PagedResponse<GetUserFeedViewModel>))]
public partial class JsonSerializerContext: System.Text.Json.Serialization.JsonSerializerContext
{

}
