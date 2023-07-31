using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Commands.UserCommand.DeleteUserCommand;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.DeleteUserAsync(new()
        {
            Id = request.Id
        });

        return response;
    }
}

