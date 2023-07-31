using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;
using OmegaGymServer.Application.Helper.CustomException;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCommand.UpdateSubscriptionCommand;

public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommandRequest, UpdateSubscriptionCommandResponse>
{
    readonly ISubscriptionWriteRepository _subscriptionWriteRepository;
    readonly ISubscriptionReadRepository _subscriptionReadRepository;
    readonly IMapper _mapper;

    public UpdateSubscriptionCommandHandler(ISubscriptionWriteRepository subscriptionWriteRepository, IMapper mapper, ISubscriptionReadRepository subscriptionReadRepository)
    {
        _subscriptionWriteRepository = subscriptionWriteRepository;
        _mapper = mapper;
        _subscriptionReadRepository = subscriptionReadRepository;
    }

    public async Task<UpdateSubscriptionCommandResponse> Handle(UpdateSubscriptionCommandRequest request, CancellationToken cancellationToken)
    {
        var getSubs = await _subscriptionReadRepository.GetByIdAsync(request.Id);

        getSubs.SubscriptionCategoryId = request.SubscriptionCategoryId == Guid.Empty ? getSubs.SubscriptionCategoryId : request.SubscriptionCategoryId;
        getSubs.SubscriptionTitle = request.SubscriptionTitle == null ? getSubs.SubscriptionTitle : request.SubscriptionTitle;
        getSubs.SubscriptionPrice = request.SubscriptionPrice == getSubs.SubscriptionPrice ? getSubs.SubscriptionPrice : request.SubscriptionPrice;
        getSubs.SubscriptionDescription = request.SubscriptionDescription == null ? getSubs.SubscriptionDescription : request.SubscriptionDescription;
        getSubs.SubscriptionArticlelOne = request.SubscriptionArticlelOne == null ? getSubs.SubscriptionArticlelOne : request.SubscriptionArticlelOne;
        getSubs.SubscriptionArticlelTwo = request.SubscriptionArticlelTwo == null ? getSubs.SubscriptionArticlelTwo : request.SubscriptionArticlelTwo;
        getSubs.SubscriptionArticlelThree = request.SubscriptionArticlelThree == null ? getSubs.SubscriptionArticlelThree : request.SubscriptionArticlelThree;

        var updatedData = _subscriptionWriteRepository.Update(getSubs);
        await _subscriptionWriteRepository.SaveAsync();

        var result = _mapper.Map<UpdateSubscriptionCommandResponse>(getSubs);

        return getSubs == null || result == null ? throw new DatabaseValidationException("update failed") : result;
    }
}

