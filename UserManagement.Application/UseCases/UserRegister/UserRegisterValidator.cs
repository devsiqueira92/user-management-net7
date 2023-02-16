using UserManagement.Shared.Communication.Requests;
using UserManagement.Shared.Exceptions;
using FluentValidation;

namespace UserManagement.Application.UseCases.UserRegister
{
    public class UserRegisterValidator : AbstractValidator<RegisterUserRequest>
    {

        public UserRegisterValidator()
        {
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceErrorsMessage.USER_EMAIL_EMPTY);
            When(user => !string.IsNullOrEmpty(user.Email), () =>
            {
                RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceErrorsMessage.USER_MAIL_INVALID);
            });
        }



    }
}
