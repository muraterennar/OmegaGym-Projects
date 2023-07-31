using MediatR;
using OmegaGymServer.Application.GenericRepository.UserRepo;
using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;
using OmegaGymServer.Application.Helper.CustomException;

namespace OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.UpdateUserSubscriptionCommand;

public class UpdateUserSubscriptionCommandHandler : IRequestHandler<UpdateUserSubscriptionCommandRequest, UpdateUserSubscriptionCommandResponse>
{
    readonly IReadUserSubscriptionRepository _readUserSubscriptionRepository;
    readonly IWriteUserSubscriptionRepository _writeUserSubscriptionRepository;

    public UpdateUserSubscriptionCommandHandler(IReadUserSubscriptionRepository readUserSubscriptionRepository, IWriteUserSubscriptionRepository writeUserSubscriptionRepository)
    {
        _readUserSubscriptionRepository = readUserSubscriptionRepository;
        _writeUserSubscriptionRepository = writeUserSubscriptionRepository;
    }

    public async Task<UpdateUserSubscriptionCommandResponse> Handle(UpdateUserSubscriptionCommandRequest request, CancellationToken cancellationToken)
    {
        var getModel = await _readUserSubscriptionRepository.GetByIdAsync(request.Id);

        if (getModel == null)
            throw new DatabaseValidationException("User Subscription Data Not Found");

        getModel.SubscriptionId = request.SubscriptionId;

        var updated = _writeUserSubscriptionRepository.Update(getModel);
        await _writeUserSubscriptionRepository.SaveAsync();

        return new()
        {
            UserId = getModel.UserId,
            SubscriptionId = getModel.SubscriptionId,
            IsSuccess = updated
        };
    }
}

