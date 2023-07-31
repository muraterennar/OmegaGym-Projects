using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.DTOs.OperationClaimDTOs;
using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;
using OmegaGymServer.Application.Helper.CustomException;

namespace OmegaGymServer.Persistence.Services;

public class OperationClaimService : IOperationClaimService
{
    readonly IOperationClaimReadRepository _operationClaimReadRepository;

    public OperationClaimService(IOperationClaimReadRepository operationClaimReadRepository)
    {
        _operationClaimReadRepository = operationClaimReadRepository;
    }

    public async Task<GetByNameOperationClaimDTO> GetByNameOprationClaimAsync(string name)
    {
        var getModel = await _operationClaimReadRepository.GetSingleAsync(o => o.RoleName == name);
        if (getModel == null)
            throw new DatabaseValidationException();

        return new()
        {
            Id = getModel.Id,
            RoleName = getModel.RoleName
        };
    }
}

