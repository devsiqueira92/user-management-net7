using UserManagement.Shared.Communication.Requests;
using UserManagement.Shared.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.UseCases.UserRegister;

namespace UserManagement.API.Controllers
{

    public class UserRegisterController : BaseController
    {


        [HttpPost]
        [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserRegister(
            [FromServices] IUserRegisterUseCase useCase, 
            [FromBody] RegisterUserRequest request)
        {
            
            var result = await useCase.Execute(request);
            return Created("", result);
        }

    }
}
