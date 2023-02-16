using UserManagement.Application.Services.Token;
using UserManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UserManagement.Application.Services.LoggedUser
{
    public class LoggedUser : ILoggedUser
    {
        private readonly ITokenController _tokeController;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoggedUser(ITokenController tokeController, UserManager<UserEntity> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _tokeController = tokeController;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<UserEntity> GetUserFromToken()
        {
            string authorization = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
            string token = authorization["Bearer".Length..].Trim();

            string userEmail = _tokeController.GetEmailFromToken(token);

            return await _userManager.FindByEmailAsync(userEmail);
        }
    }
}
