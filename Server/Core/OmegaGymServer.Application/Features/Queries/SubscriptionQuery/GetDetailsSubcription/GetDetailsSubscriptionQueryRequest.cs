using MediatR;

namespace OmegaGymServer.Application.Features.Queries.SubscriptionQuery.GetDetailsSubcription;

public class GetDetailsSubscriptionQueryRequest : IRequest<List<GetDetailsSubscriptionQueryResponse>>
{
    public string CategoryName { get; set; }
}

