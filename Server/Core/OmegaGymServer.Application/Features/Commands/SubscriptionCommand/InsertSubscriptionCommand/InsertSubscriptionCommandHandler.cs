using MediatR;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCommand.InsertSubscriptionCommand;

public class InsertSubscriptionCommandHandler : IRequestHandler<InsertSubscriptionCommandRequest, InsertSubscriptionCommandResponse>
{
    readonly ISubscriptionWriteRepository _subscriptionWriteRepository;

    public InsertSubscriptionCommandHandler(ISubscriptionWriteRepository subscriptionWriteRepository)
    {
        _subscriptionWriteRepository = subscriptionWriteRepository;
    }

    public async Task<InsertSubscriptionCommandResponse> Handle(InsertSubscriptionCommandRequest request, CancellationToken cancellationToken)
    {

        var addedModel = new Subscription
        {
            SubscriptionTitle = request.SubscriptionTitle,
            SubscriptionPrice = request.SubscriptionPrice,
            SubscriptionDescription = request.SubscriptionDescription,
            SubscriptionArticlelOne = request.SubscriptionArticlelOne,
            SubscriptionArticlelTwo = request.SubscriptionArticlelTwo,
            SubscriptionArticlelThree = request.SubscriptionArticlelThree,
            SubscriptionCategoryId = request.SubscriptionCategoryId
        };

        var model = await _subscriptionWriteRepository.AddAsync(addedModel);

        await _subscriptionWriteRepository.SaveAsync();

        return new()
        {
            IsSuccess = model
        };
    }
}

