using UserManagement.Application.Services.Token;
using UserManagement.Shared.Communication.Requests;
using UserManagement.Shared.Communication.Responses;
using UserManagement.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;
using System.Collections.Generic;

namespace UserManagement.Application.UseCases.Login
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ITokenController _tokenController;
        private readonly UserManager<UserEntity> _userManager;

        public LoginUseCase(ITokenController tokenController, UserManager<UserEntity> userManager)
        {
            _tokenController = tokenController;
            _userManager = userManager;
        }
        public async Task<LoginResponse> Execute(LoginRequest loginRequest)
        {
            UserEntity user = await _userManager.FindByEmailAsync(loginRequest.Email);

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequest.PasswordHash);
            if (user == null || !isValid)
            {
                throw new InvalidLoginException();
            }

            IList<string> roles = await _userManager.GetRolesAsync(user);

            return new LoginResponse
            {
                Name = user.UserName,
                Token = _tokenController.GenerateToken(user.Email, roles)
            };
        }
    }
}
