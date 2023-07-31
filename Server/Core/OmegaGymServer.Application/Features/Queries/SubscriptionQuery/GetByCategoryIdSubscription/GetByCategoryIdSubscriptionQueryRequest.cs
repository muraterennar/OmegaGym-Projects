using MediatR;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetByCategoryIdSubscription;

public class GetByCategoryIdSubscriptionQueryRequest : IRequest<GetByCategoryIdSubscriptionQueryReponse>
{
    public Guid SubscriptionCategoryId { get; set; }
}

