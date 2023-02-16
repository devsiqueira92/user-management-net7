using System.Security.Claims;

namespace UserManagement.Application.Services.Token
{
    public interface ITokenController
    {
        string GenerateToken(string userEmail, IList<string> roles);
        ClaimsPrincipal TokenValidate(string token);

        string GetEmailFromToken(string token);
    }
}
