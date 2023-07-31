using MediatR;
using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;
using OmegaGymServer.Application.Helper.CustomException;

namespace OmegaGymServer.Application.Features.Commands.OperationCliamCommand.UpdateOperationCliamCommand;

public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommandRequest, UpdateOperationClaimCommandResponse>
{
    readonly IOperationClaimReadRepository _operationClaimReadRepository;
    readonly IOperationClaimWriteRepositoory _operationClaimWriteRepositoory;

    public UpdateOperationClaimCommandHandler(IOperationClaimReadRepository operationClaimReadRepository, IOperationClaimWriteRepositoory operationClaimWriteRepositoory)
    {
        _operationClaimReadRepository = operationClaimReadRepository;
        _operationClaimWriteRepositoory = operationClaimWriteRepositoory;
    }

    public async Task<UpdateOperationClaimCommandResponse> Handle(UpdateOperationClaimCommandRequest request, CancellationToken cancellationToken)
    {
        var getModel = await _operationClaimReadRepository.GetByIdAsync(request.Id);

        if (getModel == null)
            throw new DatabaseValidationException("User not found");

        getModel.RoleName = request.RoleName == null ? getModel.RoleName : request.RoleName;

        var updated = _operationClaimWriteRepositoory.Update(getModel);
        await _operationClaimWriteRepositoory.SaveAsync();

        return new()
        {
            IsSuccess = updated
        };
    }
}

