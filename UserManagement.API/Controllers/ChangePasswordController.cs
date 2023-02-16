using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.UseCases.PasswordChange;
using UserManagement.Shared.Communication.Requests;

namespace UserManagement.API.Controllers
{
    public class ChangePasswordController : BaseController
    {

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromServices] IPasswordChangeUseCase useCase,
            [FromBody] PasswordChangeRequest request)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }
    }
}
