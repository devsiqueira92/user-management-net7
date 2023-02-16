using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Shared.Communication.Responses
{
    public class LoginResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
