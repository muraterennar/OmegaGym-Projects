using AutoMapper;
using MediatR;
using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;
using OmegaGymServer.Application.Helper.CustomException;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Features.Commands.OperationCliamCommand.InsertOperationClaimCommand;

public class InsertOperationCliamCommandHandler : IRequestHandler<InsertOperationCliamCommandRequest, InsertOperationCliamCommandResponse>
{
    readonly IOperationClaimReadRepository _operationClaimReadRepository;
    readonly IOperationClaimWriteRepositoory _operationClaimWriteRepository;

    readonly IMapper _mapper;

    public InsertOperationCliamCommandHandler(IOperationClaimReadRepository operationClaimReadRepository, IOperationClaimWriteRepositoory operationClaimWriteRepository, IMapper mapper)
    {
        _operationClaimReadRepository = operationClaimReadRepository;
        _operationClaimWriteRepository = operationClaimWriteRepository;
        _mapper = mapper;
    }

    public async Task<InsertOperationCliamCommandResponse> Handle(InsertOperationCliamCommandRequest request, CancellationToken cancellationToken)
    {
        var getModel = await _operationClaimReadRepository.GetSingleAsync(op => op.RoleName == request.RoleName);

        if (getModel != null)
            throw new DatabaseValidationException("Girilen Değere Ait Veri Bulunmaktadır");

        getModel = new OperationClaim
        {
            RoleName = request.RoleName
        };

        var added = await _operationClaimWriteRepository.AddAsync(getModel);
        await _operationClaimWriteRepository.SaveAsync();

        return new()
        {
            IsSuccess = added
        };
    }
}

