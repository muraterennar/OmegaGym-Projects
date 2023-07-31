using OmegaGymServer.Domain.Entities.Common;

namespace OmegaGymServer.Domain.Entities;

public class SubscriptionCategory : BaseEntity
{
    public string SubscriptionCategoryName { get; set; }
    public virtual Subscription Subscription { get; set; }
}

