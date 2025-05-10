using MediatR;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;
using TaskManagentment.Application.Validation;
using TaskManagentment.Application.Extensions; // ToMap() extension metodu için gerekli

namespace TaskManagentment.Application.Handlers
{
    public class LoginRequestHandler : IRequestHandler<AccountRequest, Response<LoginResponseData>>
    {
        private readonly IUserRepository _userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<LoginResponseData>> Handle(AccountRequest request, CancellationToken cancellationToken)
        {
            var validation = new LoginRequestValidation();
            var validationResult = await validation.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var user = await _userRepository.GetByFilter(x => x.Password == request.Password && x.UserName == request.Username);

                if (user != null)
                {
                    return new Response<LoginResponseData>(
                        new LoginResponseData(user.Name, user.Surname, user.AppRoleID),
                        true,
                        null,
                        null);
                }
                else
                {
                    return new Response<LoginResponseData>(
                        null,
                        false,
                        "User not found",
                        null);
                }
            }
            else
            {
                var errorList = validationResult.Errors.ToMap();
                return new Response<LoginResponseData>(
                    null,
                    false,
                    null,
                    errorList);
            }
        }
    }
}
