using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.DTOs;

namespace TaskManagentment.Application.Request
{
    public record class PriorityListRequest() : IRequest<Response<List<PriorityListDtos>>>;
    public record class PriorityGetByIDRequest(int ID) : IRequest<Response<PriorityListDtos>>;
    public record class PriorityUpdateRequest(int ID, string? Definition) : IRequest<Response<NoData>>;

    public record class PriorityCreateRequest(string? Definition) : IRequest<Response<NoData>>;
    public record class PriorityDeleteRequest(int ID) : IRequest<Response<NoData>>;
}
