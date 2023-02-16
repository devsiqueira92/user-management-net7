using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.UseCases.Login;
using UserManagement.Shared.Communication.Requests;
using UserManagement.Shared.Communication.Responses;

namespace UserManagement.API.Controllers
{
    public class LoginController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AuthUser(
            [FromServices] ILoginUseCase useCase,
            [FromBody] LoginRequest request)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }
    }
}
