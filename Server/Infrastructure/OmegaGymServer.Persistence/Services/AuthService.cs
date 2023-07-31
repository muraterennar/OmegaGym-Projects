using Microsoft.AspNetCore.DataProtection;
using OmegaGymServer.Application.Abstract.Mail;
using OmegaGymServer.Application.Abstract.Services;
using OmegaGymServer.Application.Abstract.Token;
using OmegaGymServer.Application.DTOs;
using OmegaGymServer.Application.DTOs.AuthDTOs;
using OmegaGymServer.Application.Features.Commands.AuthCommand.LoginCommand;
using OmegaGymServer.Application.Features.Commands.AuthCommand.RegisterCommand;
using OmegaGymServer.Application.GenericRepository.OperationClaimRepo;
using OmegaGymServer.Application.GenericRepository.UserRepo;
using OmegaGymServer.Application.Helper;
using OmegaGymServer.Application.Helper.CustomException;
using OmegaGymServer.Application.Helper.Securtiy;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Persistence.Services;

public class AuthService : IAuthService
{
    readonly IUserReadRepository _userReadRepository;
    readonly IUserWriteRepository _userWriteRepository;
    readonly IOperationClaimReadRepository _operationClaimReadRepository;
    readonly ITokenHelper _tokenHelper;
    readonly IMailService _mailService;
    public AuthService(IUserReadRepository userReadRepository, IOperationClaimReadRepository operationClaimReadRepository, ITokenHelper tokenHelper, IUserWriteRepository userWriteRepository, IMailService mailService)
    {
        _userReadRepository = userReadRepository;
        _operationClaimReadRepository = operationClaimReadRepository;
        _tokenHelper = tokenHelper;
        _userWriteRepository = userWriteRepository;
        _mailService = mailService;
    }


    public async Task<LoginCommandResponse> LoginAsync(LoginDTO loginDTO)
    {
        var dbUser = await _userReadRepository.GetSingleAsync(e => e.Email == loginDTO.Email);
        bool IsSuccess = PasswordEncrypter.VerifyPasswordHash(loginDTO.Password, dbUser.PasswordHash, dbUser.PasswordSalt);

        if (dbUser == null || IsSuccess == false)
            throw new DatabaseValidationException("The email or password is incorrect, please try again.");

        //GET User Role
        var operationClaim = await _operationClaimReadRepository.GetByIdAsync(dbUser.OperationClaimId);


        AccessToken accessToken = await _tokenHelper.CreateToken(dbUser, operationClaim.RoleName);
        return new()
        {
            Token = accessToken.Token,
            ExpirationDate = accessToken.ExpirationDate
        };
    }

    public async Task<RegisterCommandResponse> RegisterAsync(RegisterDTO registerDTO)
    {
        // user to check
        var dbuser = await _userReadRepository.GetSingleAsync(e => e.Email == registerDTO.Email);
        if (dbuser != null)
            throw new DatabaseValidationException("The user exists");

        byte[] passwordHash, passwordSalt;

        PasswordEncrypter.Encrpt(registerDTO.Password, out passwordHash, out passwordSalt);

        var registration = await _userWriteRepository.AddAsync(new User
        {
            FirstName = registerDTO.FirstName,
            LastName = registerDTO.LastName,
            Email = registerDTO.Email,
            Gender = registerDTO.Gender,
            UserName = registerDTO.UserName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        });

        // create user
        await _userWriteRepository.SaveAsync();

        // Get User Role
        var getUser = await _userReadRepository.GetSingleAsync(e => e.Email == registerDTO.Email);
        var operationClaim = await _operationClaimReadRepository.GetByIdAsync(getUser.OperationClaimId);

        var tokenHelper = await _tokenHelper.CreateToken(getUser, operationClaim.RoleName);

        return new()
        {
            Token = tokenHelper.Token,
            ExpirationDate = tokenHelper.ExpirationDate
        };
    }

    // =============== Reset Password Operation ===============

    public async Task ResetPasswordSendEmailAsync(string email)
    {
        User getUser = await _userReadRepository.GetSingleAsync(u => u.Email == email);
        if (getUser != null)
        {
            string resetToken = await GeneratePasswordTokenAsync(getUser.Id);
            resetToken = resetToken.TokenEncoding();

            await _mailService.SendPasswordResetMailAsync(email, getUser.Id.ToString(), resetToken);
        }
    }

    public async Task<bool> VerifyPasswordTokenAsync(string userId, string resetToken)
    {
        User getUser = await _userReadRepository.GetByIdAsync(Guid.Parse(userId));
        if (getUser != null)
        {
            resetToken = resetToken.TokenDecoding();

            return await VerifyUserPasswordTokenAsync(userId, resetToken);
        }

        return false;
    }

    // =============== Two Factor Auth Operation ===============

    public async Task<string> SendSingleCodeAsync(string email)
    {
        var getUserByEmail = await _userReadRepository.GetSingleAsync(u => u.Email == email);
        if (getUserByEmail != null)
        {
            //6 Haneli kod oluşturuluyor
            string generateCode = GenerateRandomNumericCode(6);
            getUserByEmail.SingleCode = generateCode;
            await _userWriteRepository.SaveAsync();
            await _mailService.SendTwoFactorAuthAsync(email, getUserByEmail.SingleCode);

            return generateCode;
        }
        throw new TwoFactorAuthException();
    }

    public async Task<bool> TwoFactorAuthAsync(string email, string singleCode)
    {
        var getUserByEmail = await _userReadRepository.GetSingleAsync(u => u.Email == email);
        if (getUserByEmail != null)
        {
            string code = getUserByEmail.SingleCode;
            if (code == singleCode)
            {
                getUserByEmail.SingleCode = null;
                await _userWriteRepository.SaveAsync();
                return true;
            }
            return false;
        }
        return false;
    }


    // ###################### Secret Operation

    private async Task<string> GeneratePasswordTokenAsync(Guid userId)
    {
        User getUser = await _userReadRepository.GetByIdAsync(userId);
        string resetToken = Guid.NewGuid().ToString();

        getUser.SecurityStamp = resetToken;
        await _userWriteRepository.SaveAsync();

        return resetToken;
    }

    private async Task<bool> VerifyUserPasswordTokenAsync(string userId, string resetToken)
    {
        User getUser = await _userReadRepository.GetByIdAsync(Guid.Parse(userId));
        if (getUser != null)
        {
            bool state = getUser.SecurityStamp == resetToken;
            if (state)
                return true;
            return false;
        }
        return false;
    }

    private string GenerateRandomNumericCode(int length)
    {
        const string numericChars = "0123456789";
        Random random = new Random();
        char[] codeChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            int index = random.Next(numericChars.Length);
            codeChars[i] = numericChars[index];
        }
        return new string(codeChars);
    }
}

