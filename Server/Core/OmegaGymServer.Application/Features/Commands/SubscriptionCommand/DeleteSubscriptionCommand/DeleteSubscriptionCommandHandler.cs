using MediatR;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;
using OmegaGymServer.Application.Helper.CustomException;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCommand.DeleteSubscriptionCommand;

public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommandRequest, DeleteSubscriptionCommandResponse>
{
    readonly ISubscriptionReadRepository _subscriptionReadRepository;
    readonly ISubscriptionWriteRepository _subscriptionWriteRepository;

    public DeleteSubscriptionCommandHandler(ISubscriptionWriteRepository subscriptionWriteRepository, ISubscriptionReadRepository subscriptionReadRepository)
    {
        _subscriptionWriteRepository = subscriptionWriteRepository;
        _subscriptionReadRepository = subscriptionReadRepository;
    }

    public async Task<DeleteSubscriptionCommandResponse> Handle(DeleteSubscriptionCommandRequest request, CancellationToken cancellationToken)
    {
        var getModel = await _subscriptionReadRepository.GetByIdAsync(request.Id);
        if (getModel == null)
            throw new DatabaseValidationException("The data for the entered Id could not be found.");

        var deletedModel = await _subscriptionWriteRepository.RemoveAsync(getModel.Id);
        await _subscriptionWriteRepository.SaveAsync();

        return new()
        {
            IsSuccess = deletedModel == false ? false : true
        };
    }
}

