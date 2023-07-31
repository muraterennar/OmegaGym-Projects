using MediatR;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByIdSubscription;

public class GetByIdSubscriptionQueryRequest : IRequest<GetByIdSubscriptionQueryResponse>
{
    public Guid Id { get; set; }
}

