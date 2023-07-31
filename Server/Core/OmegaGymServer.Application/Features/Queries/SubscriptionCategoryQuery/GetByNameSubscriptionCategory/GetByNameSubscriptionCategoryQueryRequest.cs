using MediatR;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByNameSubscriptionCategory;

public class GetByNameSubscriptionCategoryQueryRequest : IRequest<GetByNameSubscriptionCategoryQueryResponse>
{
    public string SubscriptionCategoryName { get; set; }
}

