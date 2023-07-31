using MediatR;
using OmegaGymServer.Application.GenericRepository.UserRepo;
using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Commands.UserSubscriptionCommand.InsertUserSubscriptionCommand;

public class InsertUserSubscriptionCommandHandler : IRequestHandler<InsertUserSubscriptionCommandRequest, InsertUserSubscriptionCommandResponse>
{
    readonly IReadUserSubscriptionRepository _readUserSubscriptionRepository;
    readonly IWriteUserSubscriptionRepository _writeUserSubscriptionRepository;
    readonly IUserReadRepository _userReadRepository;
    readonly IUserWriteRepository _userWriteRepository;

    public InsertUserSubscriptionCommandHandler(IReadUserSubscriptionRepository readUserSubscriptionRepository, IWriteUserSubscriptionRepository writeUserSubscriptionRepository, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
    {
        _readUserSubscriptionRepository = readUserSubscriptionRepository;
        _writeUserSubscriptionRepository = writeUserSubscriptionRepository;
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<InsertUserSubscriptionCommandResponse> Handle(InsertUserSubscriptionCommandRequest request, CancellationToken cancellationToken)
    {

        var newUserSubsc = new UserSubscription
        {
            UserId = request.UserId,
            SubscriptionId = request.SubscriptionId
        };


        var added = await _writeUserSubscriptionRepository.AddAsync(newUserSubsc);
        await _writeUserSubscriptionRepository.SaveAsync();

        var getUserById = await _userReadRepository.GetByIdAsync(newUserSubsc.UserId);
        var getSubscriptionByUserId = await _readUserSubscriptionRepository.GetSingleAsync(s => s.UserId == getUserById.Id);

        if (getUserById != null || getSubscriptionByUserId != null)
        {
            getUserById.UserSubscriptionId = getSubscriptionByUserId.Id == Guid.Empty ? getUserById.OperationClaimId : getSubscriptionByUserId.Id;
            _userWriteRepository.Update(getUserById);
        }
        await _userWriteRepository.SaveAsync();

        return new()
        {
            IsSuccess = added
        };
    }
}

