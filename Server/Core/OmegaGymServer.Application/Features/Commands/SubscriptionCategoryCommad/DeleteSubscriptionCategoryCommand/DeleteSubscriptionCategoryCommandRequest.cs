using MediatR;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.DeleteSubscriptionCategoryCommand;

public class DeleteSubscriptionCategoryCommandRequest : IRequest<DeleteSubscriptionCategoryCommandResponse>
{
    public Guid Id { get; set; }
}

