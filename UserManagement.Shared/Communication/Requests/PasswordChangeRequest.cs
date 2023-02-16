
namespace UserManagement.Shared.Communication.Requests
{
    public class PasswordChangeRequest
    {
        public string NewPassword { get; set; }
        public string CurrentPassword { get; set; }
    }
}
