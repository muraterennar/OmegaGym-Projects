using MediatR;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByNameSubscription;

public class GetByNameSubscriptionQueryRequest : IRequest<GetByNameSubscriptionQueryResponse>
{
    public string SubscriptionTitle { get; set; }
}

