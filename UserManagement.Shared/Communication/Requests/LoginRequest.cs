namespace UserManagement.Shared.Communication.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
