using MediatR;
using OmegaGymServer.Application.GenericRepository.SubscriptionCategoryRepo;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.InsertSubscriptionCategoryCommand;

public class InsertSubscriptionCategoryQueryHandler : IRequestHandler<InsertSubscriptionCategoryQueryRequest, InsertSubscriptionCategoryQueryResponse>
{
    readonly ISubscriptionCategoryWriteRepository _subscriptionCategoryWriteRepository;

    public InsertSubscriptionCategoryQueryHandler(ISubscriptionCategoryWriteRepository subscriptionCategoryWriteRepository)
    {
        _subscriptionCategoryWriteRepository = subscriptionCategoryWriteRepository;
    }

    public async Task<InsertSubscriptionCategoryQueryResponse> Handle(InsertSubscriptionCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        bool model = await _subscriptionCategoryWriteRepository.AddAsync(new()
        {
            SubscriptionCategoryName = request.SubscriptionCategoryName
        });

        await _subscriptionCategoryWriteRepository.SaveAsync();

        return new()
        {
            IsSuuccess = model
        };
    }
}

