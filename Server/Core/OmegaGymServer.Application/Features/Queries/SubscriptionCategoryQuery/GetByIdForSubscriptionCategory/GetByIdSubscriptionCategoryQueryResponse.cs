using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByIdForSubscriptionCategory;

public class GetByIdSubscriptionCategoryQueryResponse
{
    public Guid Id { get; set; }
    public string SubscriptionCategoryName { get; set; }
}

