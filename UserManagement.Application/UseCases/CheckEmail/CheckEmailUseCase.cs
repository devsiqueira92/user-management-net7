using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.UseCases.CheckEmail
{
    public class CheckEmailUseCase : ICheckEmailUseCase
    {
        private readonly UserManager<UserEntity> _userManager;

        public CheckEmailUseCase(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Execute(string email)
        {
            UserEntity user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                user = null;
                return false;
            }

            return true;
        }
    }
}
