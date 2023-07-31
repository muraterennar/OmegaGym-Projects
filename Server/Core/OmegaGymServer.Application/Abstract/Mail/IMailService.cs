namespace OmegaGymServer.Application.Abstract.Mail;

public interface IMailService
{
    Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true);
    Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true);
    Task SendPasswordResetMailAsync(string to, string userId, string resetToken);
    Task SendTwoFactorAuthAsync(string to, string singleCode);
    Task SendTemporaryPasswordAsync(string to, string temporaryPassword);

    Task FranchisingMailAsync(string to, string firstName, string lastName);
    Task FranchisingMailToAdminAsync(string to, string firstName, string lastName, string email, string phone);
}

