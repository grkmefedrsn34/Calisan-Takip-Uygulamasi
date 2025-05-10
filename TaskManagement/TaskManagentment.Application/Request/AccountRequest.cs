using MediatR;
using MediatR;
using TaskManagentment.Application.DTOs;

namespace TaskManagentment.Application.Request
{
    public record AccountRequest(string Username, string Password) : IRequest<Response<LoginResponseData>>;
}
