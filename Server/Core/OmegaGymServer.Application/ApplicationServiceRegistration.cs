using System.Reflection;
using System.Security.Claims;
using System.Text;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OmegaGymServer.Application.Abstract.Token;

namespace OmegaGymServer.Application;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assm = Assembly.GetExecutingAssembly();
        services.AddMediatR(typeof(ApplicationServiceRegistration));
        services.AddMediatR(assm);
        services.AddAutoMapper(assm);
        services.AddValidatorsFromAssembly(assm);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = tokenOptions.Issuer,
                ValidAudience = tokenOptions.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                NameClaimType = ClaimTypes.Name
            };
        });
    }
}

