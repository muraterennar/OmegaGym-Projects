using MediatR;
using OmegaGymServer.Application.Abstract.Services;

namespace OmegaGymServer.Application.Features.Commands.AuthCommand.RegisterCommand;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
{
    readonly IAuthService _authService;

    public RegisterCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _authService.RegisterAsync(new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Gender = request.Gender,
            UserName = request.UserName,
            Password = request.Password
        });

        return response;
    }
}

