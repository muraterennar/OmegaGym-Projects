using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;

namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetBySubscriptionIdUserSubscription;

public class GetBySubscriptionIdUserSubscriptionQueryHandler : IRequestHandler<GetBySubscriptionIdUserSubscriptionQueryRequest, GetBySubscriptionIdUserSubscriptionQueryResponse>
{
    readonly IReadUserSubscriptionRepository _readUserSubscriptionRepository;
    readonly IMapper _mapper;

    public GetBySubscriptionIdUserSubscriptionQueryHandler(IReadUserSubscriptionRepository readUserSubscriptionRepository, IMapper mapper)
    {
        _readUserSubscriptionRepository = readUserSubscriptionRepository;
        _mapper = mapper;
    }

    public async Task<GetBySubscriptionIdUserSubscriptionQueryResponse> Handle(GetBySubscriptionIdUserSubscriptionQueryRequest request, CancellationToken cancellationToken)
    {
        var model = await _readUserSubscriptionRepository.GetSingleAsync(us => us.SubscriptionId == request.SubscriptionId);

        var result = _mapper.Map<GetBySubscriptionIdUserSubscriptionQueryResponse>(model);

        return model == null || result == null ? throw new Exception("Searched value not found") : result;
    }
}

