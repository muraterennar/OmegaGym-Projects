using MediatR;
using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;
using OmegaGymServer.Application.Helper.CustomException;

namespace OmegaGymServer.Application.Features.Commands.OperationCliamCommand.DeleteOperationClaimCommand;

public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommandRequest, DeleteOperationClaimCommandResponse>
{
    readonly IOperationClaimReadRepository _operationClaimReadRepository;
    readonly IOperationClaimWriteRepositoory _operationClaimWriteRepositoory;

    public DeleteOperationClaimCommandHandler(IOperationClaimReadRepository operationClaimReadRepository, IOperationClaimWriteRepositoory operationClaimWriteRepositoory)
    {
        _operationClaimReadRepository = operationClaimReadRepository;
        _operationClaimWriteRepositoory = operationClaimWriteRepositoory;
    }

    public async Task<DeleteOperationClaimCommandResponse> Handle(DeleteOperationClaimCommandRequest request, CancellationToken cancellationToken)
    {
        var getModel = await _operationClaimReadRepository.GetByIdAsync(request.Id);

        if (getModel == null)
            throw new DatabaseValidationException("Data not found");

        var deleted = await _operationClaimWriteRepositoory.RemoveAsync(getModel.Id);
        await _operationClaimWriteRepositoory.SaveAsync();

        return new()
        {
            IsSuccess = deleted
        };

    }
}

