
using System;

namespace UserManagement.Shared.Exceptions
{
    public class BaseException : SystemException
    {
        public BaseException(string message): base(message)
        {

        }
    }
}
