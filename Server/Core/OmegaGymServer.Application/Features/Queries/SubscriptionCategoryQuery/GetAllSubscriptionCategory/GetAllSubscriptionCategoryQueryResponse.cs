using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetAllSubscriptionCategory;

public class GetAllSubscriptionCategoryQueryResponse
{
    public Guid Id { get; set; }
    public string SubscriptionCategoryName { get; set; }
}

