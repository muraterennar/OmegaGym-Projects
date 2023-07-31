using MediatR;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.UpdateSubscriptionCategoryCommand;

public class UpdateSubscriptionCategoryCommandRequest : IRequest<UpdateSubscriptionCategoryCommandResponse>
{
    public Guid Id { get; set; }
    public string SubscriptionCategoryName { get; set; }
}

