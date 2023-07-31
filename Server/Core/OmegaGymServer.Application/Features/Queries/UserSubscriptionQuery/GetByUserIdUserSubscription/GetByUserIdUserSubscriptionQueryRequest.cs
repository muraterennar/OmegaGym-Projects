using MediatR;

namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByUserIdUserSubscription;

public class GetByUserIdUserSubscriptionQueryRequest : IRequest<GetByUserIdUserSubscriptionQueryResponse>
{
    public Guid UserId { get; set; }
}

