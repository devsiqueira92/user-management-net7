using UserManagement.Shared.Communication.Requests;
using UserManagement.Shared.Communication.Responses;
using UserManagement.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using UserManagement.Domain.Entities;
using UserManagement.Application.Services.LoggedUser;

namespace UserManagement.Application.UseCases.PasswordChange
{
    public class PasswordChangeUseCase : IPasswordChangeUseCase
    {
        private readonly ILoggedUser _userLogged;
        private readonly UserManager<UserEntity> _userManager;

        public PasswordChangeUseCase(UserManager<UserEntity> userManager, ILoggedUser userLogged)
        {
            _userManager = userManager;
            _userLogged = userLogged;
        }

        public async Task<PasswordChangeResponse> Execute(PasswordChangeRequest passwordChangeRequest)
        {
            UserEntity userLogged = await _userLogged.GetUserFromToken();
            IdentityResult result = await _userManager.ChangePasswordAsync(userLogged, passwordChangeRequest.CurrentPassword, passwordChangeRequest.NewPassword);

            if (!result.Succeeded)
            {
                List<string> errorMessage = result.Errors.Select(error => error.Description).ToList();
                throw new ValidationErrorsExceptions(errorMessage);
            }

            return new PasswordChangeResponse
            {
                IsSuccess = true
            };
        }
    }
}
