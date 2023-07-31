using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Commands.UserCommand.UpdateUserCommand;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
{
    readonly IUserService _userService;

    public UpdateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        UpdateUserCommandResponse response = await _userService.UpdateUserAsync(new()
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Email = request.Email,
            Phone = request.Phone,
            Gender = request.Gender,
            OperationClaimId = request.OperationClaimId
        });

        return response;
    }
}

