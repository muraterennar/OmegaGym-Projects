using System;
using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.UserSubscriptionRepo;

namespace OmegaGymServer.Application.Features.Queries.UserSubscriptionQuery.GetAllUserSubscription
{
    public class GetAllUserSubscriptionHandler : IRequestHandler<GetAllUserSubscriptionQueryRequest, List<GetAllUserSubscriptionQueryResponse>>
    {
        readonly IReadUserSubscriptionRepository _userSubscriptionRepository;
        readonly IMapper _mapper;

        public GetAllUserSubscriptionHandler(IReadUserSubscriptionRepository userSubscriptionRepository, IMapper mapper)
        {
            _userSubscriptionRepository = userSubscriptionRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllUserSubscriptionQueryResponse>> Handle(GetAllUserSubscriptionQueryRequest request, CancellationToken cancellationToken)
        {
            var model = _userSubscriptionRepository.GetAll();

            var result = _mapper.Map<List<GetAllUserSubscriptionQueryResponse>>(model);

            return result.Select(i => new GetAllUserSubscriptionQueryResponse
            {
                Id = i.Id,
                CreatedDate = i.CreatedDate,
                UpdatedDate = i.UpdatedDate,
                SubscriptionId = i.SubscriptionId,
                UserId = i.UserId,
            }).ToList();
        }
    }
}

