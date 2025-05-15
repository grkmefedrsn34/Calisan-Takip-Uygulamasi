using MediatR;
using MediatR;
using TaskManagentment.Application.DTOs;

namespace TaskManagentment.Application.Request
{
    public record AccountRequest(string? Username, string? Password, bool rememberMe = false) : IRequest<Response<LoginResponseDto>>;
    public record RegistarRequest(string? Username, string? Password, string ConfirmPassword, string? Name, string? Surname) : IRequest<Response<NoData>>;
}
