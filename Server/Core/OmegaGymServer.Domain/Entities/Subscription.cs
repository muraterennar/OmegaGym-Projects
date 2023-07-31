using OmegaGymServer.Domain.Entities.Common;

namespace OmegaGymServer.Domain.Entities;

public class Subscription : BaseEntity
{
    public Guid SubscriptionCategoryId { get; set; }

    public string SubscriptionTitle { get; set; }
    public string SubscriptionDescription { get; set; }
    public decimal SubscriptionPrice { get; set; }

    public string SubscriptionArticlelOne { get; set; }
    public string SubscriptionArticlelTwo { get; set; }
    public string SubscriptionArticlelThree { get; set; }

    public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }

    public virtual ICollection<SubscriptionCategory> SubscriptionCategories { get; set; }

}

