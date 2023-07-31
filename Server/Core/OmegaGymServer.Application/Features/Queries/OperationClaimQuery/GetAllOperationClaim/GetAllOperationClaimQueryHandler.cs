using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;

namespace OmegaGymServer.Application.Features.Queries.OperationClaimQuery.GetAllOperationClaim;

public class GetAllOperationClaimQueryHandler : IRequestHandler<GetAllOperationClaimQueryRequest, List<GetAllOperationClaimQueryResponse>>
{
    readonly IOperationClaimReadRepository _operationClaimReadRepository;
    readonly IMapper _mapper;

    public GetAllOperationClaimQueryHandler(IOperationClaimReadRepository operationClaimReadRepository, IMapper mapper)
    {
        _operationClaimReadRepository = operationClaimReadRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllOperationClaimQueryResponse>> Handle(GetAllOperationClaimQueryRequest request, CancellationToken cancellationToken)
    {
        var model = _operationClaimReadRepository.GetAll();

        //var result = _mapper.Map<List<GetAllOperationClaimQueryResponse>>(model);

        return model.Select(s => new GetAllOperationClaimQueryResponse
        {
            Id = s.Id,
            RoleName = s.RoleName,
            CreatedDate = s.CreatedDate,
            UpdatedDate = s.UpdatedDate
        }).ToList();
    }
}