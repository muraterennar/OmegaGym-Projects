using System.Data;
using System.Xml.Linq;
using OmegaGymServer.Application.DTOs.UserDTOs;
using OmegaGymServer.Application.Features.Commands.UserCommand.DeleteUserCommand;
using OmegaGymServer.Application.Features.Commands.UserCommand.InsertUserCommand;
using OmegaGymServer.Application.Features.Commands.UserCommand.UpdateUserCommand;

namespace OmegaGymServer.Application.Abstract.Services;

public interface IUserService
{
    Task<InsertUserCommandResponse> AddUserAsync(AddUserDTO userDTO);
    Task<UpdateUserCommandResponse> UpdateUserAsync(UpdateUserDTO userDTO);
    Task<bool> UpdatePassword(UpdatePasswordDTO updatePasswordDTO);
    Task<DeleteUserCommandResponse> DeleteUserAsync(DeleteUserDTO userDTO);
    Task<bool> HasRolePermissionToRoleNameAsync(string name, string[] roles);
}

