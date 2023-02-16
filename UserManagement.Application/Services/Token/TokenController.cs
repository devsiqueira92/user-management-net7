using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace UserManagement.Application.Services.Token
{
    internal class TokenController : ITokenController
    {
        private const string EmailAlias = "eml";
        private readonly double _lifeTimeTokenInMinutes;
        private readonly string _securityKey;

        public TokenController(double lifeTimeTokenInMinutes, string securityKey)
        {
            _lifeTimeTokenInMinutes = lifeTimeTokenInMinutes;
            _securityKey = securityKey;
        }

        public string GenerateToken(string userEmail, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(EmailAlias, userEmail),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "localhost",
                Audience = "localhost",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_lifeTimeTokenInMinutes),
                SigningCredentials = new SigningCredentials(SymmetricKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        public ClaimsPrincipal TokenValidate(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validatorParams = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                IssuerSigningKey = SymmetricKey(),
                ClockSkew = new TimeSpan(0),
                ValidateIssuer = false,
                ValidateAudience = false

            };

            return tokenHandler.ValidateToken(token, validatorParams, out _);
        }

        public string GetEmailFromToken(string token)
        {
            ClaimsPrincipal claims = TokenValidate(token);

            return claims.FindFirst(EmailAlias).Value;
        }

        private SymmetricSecurityKey SymmetricKey()
        {
            byte[] symmetricKey = Convert.FromBase64String(_securityKey);
            return new SymmetricSecurityKey(symmetricKey);
        }

    }
}
