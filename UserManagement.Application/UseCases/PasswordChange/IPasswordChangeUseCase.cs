
using UserManagement.Shared.Communication.Requests;
using UserManagement.Shared.Communication.Responses;
using System.Threading.Tasks;

namespace UserManagement.Application.UseCases.PasswordChange
{
    public interface IPasswordChangeUseCase
    {
        Task<PasswordChangeResponse> Execute(PasswordChangeRequest passwordRecoveryRequest);
    }
}
