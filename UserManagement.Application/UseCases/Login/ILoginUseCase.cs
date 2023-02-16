using UserManagement.Shared.Communication.Requests;
using UserManagement.Shared.Communication.Responses;
using System.Threading.Tasks;

namespace UserManagement.Application.UseCases.Login
{
    public interface ILoginUseCase
    {
        Task<LoginResponse> Execute(LoginRequest loginRequest);
    }
}
