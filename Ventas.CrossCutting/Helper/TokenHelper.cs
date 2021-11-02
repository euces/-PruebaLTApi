using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Ventas.Interface.Service;
using Ventas.Common.Setting;

namespace Ventas.CrossCutting.Helper
{
    public class TokenHelper : ITokenHelper
    {
        private readonly JwtSettings jwtSettings;

        public TokenHelper(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings.Value;
        }
        public string GetToken(int expirationDays, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, userName)
                }),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(expirationDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateCurrentToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.jwtSettings.Secret));

            var validIssuer = this.jwtSettings.ValidIssuer;
            var validAudience = this.jwtSettings.ValidAudience;

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidIssuer = validIssuer,
                    ValidAudience = validAudience,
                    IssuerSigningKey = key,
                    LifetimeValidator = this.LifetimeValidator,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}
