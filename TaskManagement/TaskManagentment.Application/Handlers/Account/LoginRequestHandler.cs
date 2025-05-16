using MediatR;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;
using TaskManagentment.Application.Validation;
using TaskManagentment.Application.Extensions;
using TaskManagentment.Application.Enums;
using TaskManagentment.Application.Validation.Account;

namespace TaskManagentment.Application.Handlers.Account
{
    public class LoginRequestHandler : IRequestHandler<AccountRequest, Response<LoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<LoginResponseDto>> Handle(AccountRequest request, CancellationToken cancellationToken)
        {
            var validation = new LoginRequestValidation();
            var validationResult = await validation.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var user = await _userRepository.GetByFilterAsync(x =>
                    x.Password == request.Password && x.UserName == request.Username);

                if (user != null)
                {
                    var type = (RoleType)user.AppRoleID;

                    var loginDto = new LoginResponseDto(user.Name, user.Surname, type, user.ID);

                    return new Response<LoginResponseDto>(
                        loginDto,
                        true,
                        null,
                        null);
                }
                else
                {
                    return new Response<LoginResponseDto>(
                        null,
                        false,
                        "User not found",
                        null);
                }
            }
            else
            {
                var errorList = validationResult.Errors.ToMap();
                return new Response<LoginResponseDto>(
                    null,
                    false,
                    null,
                    errorList);
            }
        }
    }
}
