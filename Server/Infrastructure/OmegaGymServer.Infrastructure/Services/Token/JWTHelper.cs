using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using OmegaGymServer.Application.Abstract.Token;
using OmegaGymServer.Domain.Entities;
using OmegaGymServer.Application.DTOs;

namespace OmegaGymServer.Infrastructure.Services.Token
{
    public class JWTHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JWTHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public async Task<AccessToken> CreateToken(User user, string role)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, role);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new()
            {
                ExpirationDate = _accessTokenExpiration,
                Token = token
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, string role)
        {
            var jwt = new JwtSecurityToken(
                   issuer: tokenOptions.Issuer,
                   audience: tokenOptions.Audience,
                   expires: _accessTokenExpiration,
                   notBefore: DateTime.Now,
                   signingCredentials: signingCredentials,
                   claims: SetClaims(user, role)
                   );
            return jwt;
        }


        private static List<Claim> SetClaims(User user, string role)
        {
            var claims = new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.Gender, user.Gender)
            };

            return claims.ToList();
        }
    }
}

