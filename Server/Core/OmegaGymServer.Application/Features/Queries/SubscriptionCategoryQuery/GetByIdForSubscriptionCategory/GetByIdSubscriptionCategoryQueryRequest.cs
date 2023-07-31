using MediatR;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetByIdForSubscriptionCategory;

public class GetByIdSubscriptionCategoryQueryRequest : IRequest<GetByIdSubscriptionCategoryQueryResponse>
{
    public Guid Id { get; set; }
}

