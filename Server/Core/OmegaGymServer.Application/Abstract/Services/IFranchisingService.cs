using OmegaGymServer.Application.DTOs.FranchingDTOs;

namespace OmegaGymServer.Application.Abstract.Services;

public interface IFranchisingService
{
    List<FranchingAccept> GetAll();
    Task GetByIdAsync(Guid id);
    Task GetByTelAsync(string tel);
    Task GetByEmailAsync(string email);
    Task GetByFirstNameAsync(string firstName);
    Task GetByLastNameAsync(string lastName);

    Task AcceptAsync(FranchingAccept accept);
    Task DeleteAcceptAsync(Guid id);
}

