using MediatR;

namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByIdUserSubscription;

public class GetByIdUserSubscriptionQueryRequest : IRequest<GetByIdUserSubscriptionQueryResponse>
{
    public Guid Id { get; set; }
}

