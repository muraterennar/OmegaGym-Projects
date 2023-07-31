using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;

namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetByIdUserSubscription;

public class GetByIdUserSubscriptionQueryHandler : IRequestHandler<GetByIdUserSubscriptionQueryRequest, GetByIdUserSubscriptionQueryResponse>
{
    readonly IReadUserSubscriptionRepository _readUserSubscriptionRepository;
    readonly IMapper _mapper;

    public GetByIdUserSubscriptionQueryHandler(IReadUserSubscriptionRepository readUserSubscriptionRepository, IMapper mapper)
    {
        _readUserSubscriptionRepository = readUserSubscriptionRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdUserSubscriptionQueryResponse> Handle(GetByIdUserSubscriptionQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _readUserSubscriptionRepository.GetSingleAsync(us => us.Id == request.Id);

        var result = _mapper.Map<GetByIdUserSubscriptionQueryResponse>(model);

        return model == null || result == null ? throw new Exception("Searched value not found") : result;
    }
}

