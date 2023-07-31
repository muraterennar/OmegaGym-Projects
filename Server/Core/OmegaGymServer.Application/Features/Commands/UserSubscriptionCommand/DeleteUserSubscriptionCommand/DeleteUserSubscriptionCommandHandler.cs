using MediatR;
using OmegaGymServer.Application.GenericRepository.UserRepo;
using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;
using OmegaGymServer.Application.Helper.CustomException;

namespace OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.DeleteUserSubscriptionCommand;

public class DeleteUserSubscriptionCommandHandler : IRequestHandler<DeleteUserSubscriptionCommandRequest, DeleteUserSubscriptionCommandResponse>
{
    readonly IReadUserSubscriptionRepository _readUserSubscriptionRepository;
    readonly IWriteUserSubscriptionRepository _writeUserSubscriptionRepository;
    readonly IUserReadRepository _userReadRepository;
    readonly IUserWriteRepository _userWriteRepository;

    public DeleteUserSubscriptionCommandHandler(IReadUserSubscriptionRepository readUserSubscriptionRepository, IWriteUserSubscriptionRepository writeUserSubscriptionRepository, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
    {
        _readUserSubscriptionRepository = readUserSubscriptionRepository;
        _writeUserSubscriptionRepository = writeUserSubscriptionRepository;
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<DeleteUserSubscriptionCommandResponse> Handle(DeleteUserSubscriptionCommandRequest request, CancellationToken cancellationToken)
    {
        var getModel = await _readUserSubscriptionRepository.GetByIdAsync(request.Id);

        if (getModel == null)
            throw new DatabaseValidationException("User Subscription Data Not Found");

        var deleted = await _writeUserSubscriptionRepository.RemoveAsync(getModel.Id);

        var getUserById = await _userReadRepository.GetByIdAsync(getModel.UserId);

        if (getUserById == null)
            throw new DatabaseValidationException("User Not Found");

        getUserById.UserSubscriptionId = null;
        _userWriteRepository.Update(getUserById);

        await _userWriteRepository.SaveAsync();
        await _writeUserSubscriptionRepository.SaveAsync();

        return new()
        {
            IsSuccess = deleted
        };
    }
}

