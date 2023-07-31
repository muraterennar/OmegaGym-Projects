using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.SubscriptionCategoryRepo;
using OmegaGymServer.Application.GenericRepository.SubscriptionRepo;
using OmegaGymServer.Application.Helper.CustomException;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.DeleteSubscriptionCategoryCommand;

public class DeleteSubscriptionCategoryCommandHandler : IRequestHandler<DeleteSubscriptionCategoryCommandRequest, DeleteSubscriptionCategoryCommandResponse>
{
    readonly ISubscriptionCategoryReadRepository _subscriptionCategoryReadRepository;
    readonly ISubscriptionCategoryWriteRepository _subscriptionCategoryWriteRepository;
    readonly IMapper _mapper;

    public DeleteSubscriptionCategoryCommandHandler(ISubscriptionCategoryReadRepository subscriptionCategoryReadRepository, ISubscriptionCategoryWriteRepository subscriptionCategoryWriteRepository, IMapper mapper)
    {
        _subscriptionCategoryReadRepository = subscriptionCategoryReadRepository;
        _subscriptionCategoryWriteRepository = subscriptionCategoryWriteRepository;
        _mapper = mapper;
    }

    public async Task<DeleteSubscriptionCategoryCommandResponse> Handle(DeleteSubscriptionCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var getModel = await _subscriptionCategoryReadRepository.GetByIdAsync(request.Id);

        if (getModel == null)
            throw new DatabaseValidationException("The data for the entered Id could not be found.");

        var deletedModel = await _subscriptionCategoryWriteRepository.RemoveAsync(getModel.Id);
        await _subscriptionCategoryWriteRepository.SaveAsync();


        return new()
        {
            IsSuccess = deletedModel == false ? false : true
        };
    }
}

