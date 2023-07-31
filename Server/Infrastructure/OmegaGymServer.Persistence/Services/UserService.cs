using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OmegaGymServer.Application.Abstract.Mail;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.DTOs.UserDTOs;
using OmegaGymServer.Application.Features.Commands.UserCommand.DeleteUserCommand;
using OmegaGymServer.Application.Features.Commands.UserCommand.InsertUserCommand;
using OmegaGymServer.Application.Features.Commands.UserCommand.UpdateUserCommand;
using OmegaGymServer.Application.GenericRepository.UserRepo;
using OmegaGymServer.Application.Helper;
using OmegaGymServer.Application.Helper.CustomException;
using OmegaGymServer.Application.Helper.Securtiy;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Persistence.Consts;

namespace OmegaGymServer.Persistence.Services;

public class UserService : IUserService
{
    readonly IUserReadRepository _userReadRepository;
    readonly IUserWriteRepository _userWriteRepository;
    readonly IOperationClaimService _operationClaimService;
    readonly IConfiguration _configuration;
    readonly IMailService _mailService;

    public UserService(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IConfiguration configuration, IOperationClaimService operationClaimService, IMailService mailService)
    {
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _configuration = configuration;
        _operationClaimService = operationClaimService;
        _mailService = mailService;
    }

    public async Task<InsertUserCommandResponse> AddUserAsync(AddUserDTO userDTO)
    {
        var getModel = await _userReadRepository.GetSingleAsync(e => e.Email == userDTO.Email);

        if (getModel != null)
            throw new DatabaseValidationException("There is a user belonging to the entered e-mail");

        //!: user eklerken geçici şifre oluşturup eklemeyi yap (isim-soyisim ile ekleyip bir kombinasyon).
        //TODO: oluşan şifreyi mail olarak göndermeyi ayarla.
        byte[] passwordHash, passwordSalt;
        var password = GeneratePassword();
        PasswordEncrypter.Encrpt(password, out passwordHash, out passwordSalt);

        var addedUser = new User
        {
            FirstName = userDTO.FirstName,
            LastName = userDTO.LastName,
            UserName = userDTO.UserName,
            Email = userDTO.Email,
            Phone = userDTO.Phone,
            Gender = userDTO.Gender,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
        };

        var addedModel = await _userWriteRepository.AddAsync(addedUser);
        await _userWriteRepository.SaveAsync();
        var getAddedModel = await _userReadRepository.GetSingleAsync(u => u.Email == addedUser.Email);
        await _mailService.SendTemporaryPasswordAsync(getAddedModel.Email, password);

        return new()
        {
            Id = getAddedModel.Id,
            FirstName = getAddedModel.FirstName,
            LastName = getAddedModel.LastName,
            UserName = getAddedModel.UserName,
            Email = getAddedModel.Email,
            Phone = getAddedModel.Phone,
            OperationClaimId = getAddedModel.OperationClaimId
        };
    }

    public async Task<UpdateUserCommandResponse> UpdateUserAsync(UpdateUserDTO userDTO)
    {

        var getModel = await _userReadRepository.GetByIdAsync(userDTO.Id);

        if (getModel == null)
            throw new DatabaseValidationException("Searcdeh data not found");

        getModel.FirstName = userDTO.FirstName == null ? getModel.FirstName : userDTO.FirstName;
        getModel.LastName = userDTO.LastName == null ? getModel.LastName : userDTO.LastName;
        getModel.UserName = userDTO.UserName == null ? getModel.UserName : userDTO.UserName;
        getModel.Email = userDTO.Email == null ? getModel.Email : userDTO.Email;
        getModel.Phone = userDTO.Phone == null ? getModel.Phone : userDTO.Phone;
        getModel.Gender = userDTO.Gender == null ? getModel.Gender : userDTO.Gender;
        getModel.OperationClaimId = userDTO.OperationClaimId == Guid.Empty ? getModel.OperationClaimId : userDTO.OperationClaimId;
        _userWriteRepository.Update(getModel);
        await _userWriteRepository.SaveAsync();

        return new()
        {
            Id = getModel.Id,
            FirstName = getModel.FirstName,
            LastName = getModel.LastName,
            UserName = getModel.UserName,
            Email = getModel.Email,
            Phone = getModel.Phone,
            OperationClaimId = getModel.OperationClaimId
        };
    }

    public async Task<DeleteUserCommandResponse> DeleteUserAsync(DeleteUserDTO userDTO)
    {
        var getModel = await _userReadRepository.GetByIdAsync(userDTO.Id);

        if (getModel == null)
            throw new DatabaseValidationException("User Not Found");

        var deleted = await _userWriteRepository.RemoveAsync(getModel.Id);
        await _userWriteRepository.SaveAsync();

        return new()
        {
            IsSuccess = deleted
        };
    }

    public async Task<bool> HasRolePermissionToRoleNameAsync(string name, string[] roles)
    {
        foreach (var role in roles)
        {
            var getRole = await _operationClaimService.GetByNameOprationClaimAsync(role);
            var getUser = await _userReadRepository.Table.Include(e => e.OperationClaim).FirstOrDefaultAsync(e => e.UserName == name);

            if (getRole.Id == getUser.OperationClaimId)
                return true;
        }

        return false;
    }

    public async Task<bool> UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
    {
        User user = await _userReadRepository.GetByIdAsync(Guid.Parse(updatePasswordDTO.UserId));
        byte[] passwordHash, passwordSalt;
        if (user != null)
        {
            updatePasswordDTO.ResetToken = updatePasswordDTO.ResetToken.TokenDecoding();
            PasswordEncrypter.Encrpt(updatePasswordDTO.NewPassword, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _userWriteRepository.SaveAsync();

            ResetToken(user, updatePasswordDTO.ResetToken);

            await _userWriteRepository.SaveAsync();
            return true;
        }

        return false;
    }

    private User ResetToken(User user, string resetToken)
    {
        var state = user.SecurityStamp == resetToken;
        if (state) user.SecurityStamp = Guid.NewGuid().ToString();
        return user;
    }



    private static string GeneratePassword(int length = 12)
    {

        // Kullanılacak karakterleri birleştirir.
        string allCharacters = PasswordCharacterConst.UpperCaseLetters + PasswordCharacterConst.LowerCaseLetters + PasswordCharacterConst.Numbers + PasswordCharacterConst.SpecialCharacters;

        // Şifre uzunluğu boyunca rastgele karakterler seçer.
        StringBuilder passwordBuilder = new StringBuilder();
        Random random = new Random();

        // En az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter eklemek için başlangıç olarak bu tipteki karakterlerden rastgele birer tane eklenir.
        passwordBuilder.Append(PasswordCharacterConst.UpperCaseLetters[random.Next(PasswordCharacterConst.UpperCaseLetters.Length)]);
        passwordBuilder.Append(PasswordCharacterConst.LowerCaseLetters[random.Next(PasswordCharacterConst.LowerCaseLetters.Length)]);
        passwordBuilder.Append(PasswordCharacterConst.Numbers[random.Next(PasswordCharacterConst.Numbers.Length)]);
        passwordBuilder.Append(PasswordCharacterConst.SpecialCharacters[random.Next(PasswordCharacterConst.SpecialCharacters.Length)]);

        // Kalan karakterler rastgele seçilerek eklenir.
        for (int i = 4; i < length; i++)
        {
            passwordBuilder.Append(allCharacters[random.Next(allCharacters.Length)]);
        }

        // Şifreyi karıştırır.
        string password = new string(passwordBuilder.ToString().ToCharArray().OrderBy(x => random.Next()).ToArray());

        return password;
    }
}

