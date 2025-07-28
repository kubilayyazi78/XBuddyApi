using Mediator;

namespace XBuddy.Application.Infrastucture.PipelineBehaviours;

public class TenantCachePipelineBehaviour<TReq, TRes> : IPipelineBehavior<TReq, TRes>
    where TReq : IRequest<TRes>
    where TRes : class
{
    public ValueTask<TRes> Handle(TReq message, CancellationToken cancellationToken, MessageHandlerDelegate<TReq, TRes> next)
    {
        throw new NotImplementedException();
    }
}
