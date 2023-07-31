using OmegaGymServer.Domain.Entities.Common;

namespace OmegaGymServer.Domain.Entities;

public class UserSubscription : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid SubscriptionId { get; set; }

    public DateTime SubscriptionCreateDate { get; set; }
    public DateTime SubscriptionDate { get; set; }
    public DateTime SubscriptionEndDate { get; set; }

    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Subscription> Subscriptions { get; set; }
}

