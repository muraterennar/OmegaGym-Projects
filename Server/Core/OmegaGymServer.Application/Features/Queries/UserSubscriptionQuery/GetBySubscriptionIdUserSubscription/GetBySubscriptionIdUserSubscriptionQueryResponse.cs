namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetBySubscriptionIdUserSubscription;

public class GetBySubscriptionIdUserSubscriptionQueryResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SubscriptionId { get; set; }
}

