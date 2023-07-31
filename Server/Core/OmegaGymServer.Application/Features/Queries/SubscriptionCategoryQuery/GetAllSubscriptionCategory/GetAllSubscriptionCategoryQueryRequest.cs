using MediatR;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionCategoryQuery.GetAllSubscriptionCategory;

public class GetAllSubscriptionCategoryQueryRequest : IRequest<List<GetAllSubscriptionCategoryQueryResponse>>
{
}

