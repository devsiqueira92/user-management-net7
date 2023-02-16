using System.Threading.Tasks;

namespace UserManagement.Application.UseCases.CheckEmail
{
    public interface ICheckEmailUseCase
    {
        Task<bool> Execute(string emailRequest);
    }
}
