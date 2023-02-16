using System.Collections.Generic;

namespace UserManagement.Shared.Exceptions
{
    public class ValidationErrorsExceptions : BaseException
    {
        public List<string> ErrorsMesssages { get; set; }

        public ValidationErrorsExceptions(List<string> errorsMesssages) : base(string.Empty)
        {
            ErrorsMesssages = errorsMesssages;
        }
    }
}
