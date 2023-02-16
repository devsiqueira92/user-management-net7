using UserManagement.Shared.Communication.Requests;
using UserManagement.Shared.Communication.Responses;
using System.Threading.Tasks;

namespace UserManagement.Application.UseCases.UserRegister
{
    public interface IUserRegisterUseCase
    {
        Task<RegisterUserResponse> Execute(RegisterUserRequest registerUserRequest);
    }
}
