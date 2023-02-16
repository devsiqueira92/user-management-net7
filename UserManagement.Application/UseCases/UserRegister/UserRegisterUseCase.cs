using AutoMapper;
using UserManagement.Application.Services.Token;
using UserManagement.Shared.Communication.Requests;
using UserManagement.Shared.Communication.Responses;
using UserManagement.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using UserManagement.Domain.Entities;
using FluentValidation.Results;

namespace UserManagement.Application.UseCases.UserRegister
{
    public class UserRegisterUseCase : IUserRegisterUseCase
    {
        private readonly IMapper _mapper;
        private readonly ITokenController _tokenController;
        private readonly UserManager<UserEntity> _userManager;

        public UserRegisterUseCase(IMapper mapper,
            ITokenController tokenController,
            UserManager<UserEntity> userManager)

        {
            _mapper = mapper;
            _tokenController = tokenController;
            _userManager = userManager;
        }

        public async Task<RegisterUserResponse> Execute(RegisterUserRequest registerUserRequest)
        {
            await Validate(registerUserRequest);

            UserEntity entity = _mapper.Map<UserEntity>(registerUserRequest);
            IdentityResult isCreated = await _userManager.CreateAsync(entity, entity.PasswordHash);

            if (!isCreated.Succeeded)
            {
                List<string> errorMessage = isCreated.Errors.Select(error => error.Description).ToList();
                throw new ValidationErrorsExceptions(errorMessage);
            }

            IList<string> roles = await _userManager.GetRolesAsync(entity);
            string token = _tokenController.GenerateToken(entity.Email, roles);

            return new RegisterUserResponse
            {
                Token = token,
                UserName = entity.UserName
            };
        }

        private async Task Validate(RegisterUserRequest registerUserRequest)
        {
            UserRegisterValidator validator = new UserRegisterValidator();

            ValidationResult result = validator.Validate(registerUserRequest);

            UserEntity emailExistsOnDb = await _userManager.FindByEmailAsync(registerUserRequest.Email);

            if (emailExistsOnDb != null)
            {
                result.Errors.Add(new ValidationFailure("email", ResourceErrorsMessage.EMAIL_UNAVAILABLE));
            }

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ValidationErrorsExceptions(errorMessage);
            }
        }
    }
}
