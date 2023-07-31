using OmegaGymServer.Application.DTOs;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Application.Abstract.Token;

public interface ITokenHelper
{
    Task<AccessToken> CreateToken(User user, string role);
}

