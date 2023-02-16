namespace UserManagement.Shared.Exceptions
{
    public class InvalidLoginException: BaseException
    {
        public InvalidLoginException():base(ResourceErrorsMessage.INVALID_LOGIN)
        {

        }
    }
}
