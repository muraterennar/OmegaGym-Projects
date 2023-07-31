using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Commands.UserCommand.InsertUserCommand;

public class InsertUserCommandHandler : IRequestHandler<InsertUserCommandRequest, InsertUserCommandResponse>
{
    readonly IUserService _userService;

    public InsertUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<InsertUserCommandResponse> Handle(InsertUserCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.AddUserAsync(new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Email = request.Email,
            Phone = request.Phone,
            Gender = request.Gneder,
            OperationClaimId = request.OperationClaimId
        });

        return response;
    }
}

