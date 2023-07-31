using MediatR;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.InsertSubscriptionCategoryCommand;

public class InsertSubscriptionCategoryQueryRequest : IRequest<InsertSubscriptionCategoryQueryResponse>
{
    public string SubscriptionCategoryName { get; set; }
}

