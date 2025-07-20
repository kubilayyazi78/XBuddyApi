using System.Text.Json.Serialization;
using XBuddyModels.Queries.Feed;

namespace XBuddy.WebApi.Infrastructure.SourceGenerators;

[JsonSerializable(typeof(List<GetUserFeedViewModel>))]
public partial class JsonSerializerContext: System.Text.Json.Serialization.JsonSerializerContext
{

}
