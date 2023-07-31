using Microsoft.Extensions.Configuration;
using OmegaGymServer.Application.Abstract.Mail;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.DTOs.FranchingDTOs;
using OmegaGymServer.Application.GenericRepository.FranchisingRepo;

namespace OmegaGymServer.Persistence.Services;

public class FranchisingService : IFranchisingService
{
    readonly IFranchinsingWriteRepository _franchinsingWriteRepository;
    readonly IFranchisingReadRepository _franchisingReadRepository;
    readonly IMailService _mail;
    readonly IConfiguration _configuration;

    public FranchisingService(IFranchinsingWriteRepository franchinsingWriteRepository, IFranchisingReadRepository franchisingReadRepository, IMailService mail, IConfiguration configuration)
    {
        _franchinsingWriteRepository = franchinsingWriteRepository;
        _franchisingReadRepository = franchisingReadRepository;
        _mail = mail;
        _configuration = configuration;
    }

    public async Task AcceptAsync(FranchingAccept accept)
    {
        await _franchinsingWriteRepository.AddAsync(new()
        {
            FirstName = accept.FirstName,
            LastName = accept.LastName,
            Email = accept.Email,
            Phone = accept.Email
        });

        await _franchinsingWriteRepository.SaveAsync();

        await _mail.FranchisingMailAsync(accept.Email, accept.FirstName, accept.LastName);
        await _mail.FranchisingMailToAdminAsync(_configuration["OmegaGymInformation:email"], accept.FirstName, accept.LastName, accept.Email, accept.Phono);
    }

    public async Task DeleteAcceptAsync(Guid id)
    {
        await _franchinsingWriteRepository.RemoveAsync(id);
        await _franchinsingWriteRepository.SaveAsync();
    }

    public List<FranchingAccept> GetAll()
    {
        var model = _franchisingReadRepository.GetAll();
        return model.Select(f => new FranchingAccept
        {
            Id = f.Id,
            FirstName = f.FirstName,
            LastName = f.LastName,
            Email = f.Email,
            Phono = f.Phone
        }).ToList();
    }

    public async Task GetByEmailAsync(string email)
    {
        await _franchisingReadRepository.GetSingleAsync(x => x.Email == email);
    }

    public async Task GetByFirstNameAsync(string firstName)
    {
        await _franchisingReadRepository.GetSingleAsync(x => x.FirstName == firstName);
    }

    public async Task GetByIdAsync(Guid id)
    {
        await _franchisingReadRepository.GetByIdAsync(id);
    }

    public async Task GetByLastNameAsync(string lastName)
    {
        await _franchisingReadRepository.GetSingleAsync(x => x.LastName == lastName);
    }

    public async Task GetByTelAsync(string tel)
    {
        await _franchisingReadRepository.GetSingleAsync(x => x.Phone == tel);
    }
}

