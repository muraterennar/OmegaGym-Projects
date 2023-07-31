using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.SubscriptionCategoryRepo;
using OmegaGymServer.Application.Helper.CustomException;

namespace OmegaGymServer.Application.Features.Commands.SubscriptionCategoryCommad.UpdateSubscriptionCategoryCommand;

public class UpdateSubscriptionCategoryCommandHandler : IRequestHandler<UpdateSubscriptionCategoryCommandRequest, UpdateSubscriptionCategoryCommandResponse>
{
    readonly ISubscriptionCategoryReadRepository _subscriptionCategoryReadRepository;
    readonly ISubscriptionCategoryWriteRepository _subscriptionCategoryWriteRepository;
    readonly IMapper _mapper;

    public UpdateSubscriptionCategoryCommandHandler(ISubscriptionCategoryReadRepository subscriptionCategoryReadRepository, ISubscriptionCategoryWriteRepository subscriptionCategoryWriteRepository, IMapper mapper)
    {
        _subscriptionCategoryReadRepository = subscriptionCategoryReadRepository;
        _subscriptionCategoryWriteRepository = subscriptionCategoryWriteRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSubscriptionCategoryCommandResponse> Handle(UpdateSubscriptionCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var getModel = await _subscriptionCategoryReadRepository.GetByIdAsync(request.Id);

        if (getModel == null)
            throw new DatabaseValidationException("The data for the entered Id could not be found.");

        getModel.SubscriptionCategoryName = request.SubscriptionCategoryName == null ? getModel.SubscriptionCategoryName : request.SubscriptionCategoryName;

        var updatedModel = _subscriptionCategoryWriteRepository.Update(getModel);
        await _subscriptionCategoryWriteRepository.SaveAsync();

        var result = _mapper.Map<UpdateSubscriptionCategoryCommandResponse>(getModel);

        return result;

    }
}

