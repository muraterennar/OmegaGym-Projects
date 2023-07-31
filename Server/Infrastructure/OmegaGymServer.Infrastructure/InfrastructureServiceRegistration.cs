using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OmegaGymServer.Application.Abstract.Mail;
using OmegaGymServer.Application.Abstract.Token;
using OmegaGymServer.Infrastructure.Services.Mail;
using OmegaGymServer.Infrastructure.Services.Token;

namespace OmegaGymServer.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static void AddInfrastructureService(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assm);

        services.AddScoped<ITokenHelper, JWTHelper>();
        services.AddScoped<IMailService, MailService>();

    }
}

