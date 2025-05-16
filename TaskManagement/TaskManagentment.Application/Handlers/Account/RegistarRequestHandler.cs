using MediatR;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Extensions;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;
using TaskManagentment.Application.Validation.Account;

namespace TaskManagentment.Application.Handlers.Account
{
    public class RegistarRequestHandler : IRequestHandler<RegistarRequest, Response<NoData>>
    {
        private readonly IUserRepository _userRepository;

        public RegistarRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<NoData>> Handle(RegistarRequest request, CancellationToken cancellationToken)
        {
            var validation = new RegistarRequestValidation();
            var validationResult = await validation.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var result = await _userRepository.CreateUserAsync(request.ToMap());
                if (result > 0)
                {
                    return new Response<NoData>(
                        new NoData(),
                        true,
                        null,
                        null);
                }
                else
                {
                    return new Response<NoData>(
                        new NoData(),
                        false,
                        "User not created",
                        null);
                }
            }
            else
            {
                var errorList = validationResult.Errors.ToMap();
                return new Response<NoData>(
                    new NoData(),
                    false,
                    null,
                    errorList);
            }
        }
    }
}
