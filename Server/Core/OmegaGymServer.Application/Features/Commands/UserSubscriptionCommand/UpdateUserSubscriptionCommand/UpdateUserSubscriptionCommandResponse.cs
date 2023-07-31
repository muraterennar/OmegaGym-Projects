namespace OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.UpdateUserSubscriptionCommand;

public class UpdateUserSubscriptionCommandResponse
{
    public Guid UserId { get; set; }
    public Guid SubscriptionId { get; set; }
    public bool IsSuccess { get; set; }
}

