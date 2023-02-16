using System.Threading.Tasks;

namespace UserManagement.Application.Services.LoggedUser
{
    public interface ILoggedUser
    {
        Task<Domain.Entities.UserEntity> GetUserFromToken();
    }

}
