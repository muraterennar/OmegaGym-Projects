using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByIdUserSubscription;

public class GetByIdUserSubscriptionQueryResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SubscriptionId { get; set; }

}

