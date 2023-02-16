using System;

namespace UserManagement.Shared.Communication.Requests
{
    public class RegisterUserRequest
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
    }
}
