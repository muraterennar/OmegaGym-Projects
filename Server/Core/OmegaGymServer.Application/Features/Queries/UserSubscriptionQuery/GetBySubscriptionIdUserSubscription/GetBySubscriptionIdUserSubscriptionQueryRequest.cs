using MediatR;

namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetBySubscriptionIdUserSubscription;

public class GetBySubscriptionIdUserSubscriptionQueryRequest : IRequest<GetBySubscriptionIdUserSubscriptionQueryResponse>
{
    public Guid SubscriptionId { get; set; }
}

