﻿using KahramanYazilim.TaskManagement.Application.Dtos;
using MediatR;


namespace KahramanYazilim.TaskManagement.Application.Requests
{
    public record AppTaskListRequest : PagedRequest, IRequest<PagedResult<AppTaskListDto>>
    {
        public AppTaskListRequest(int activePage, string s) : base(activePage)
        {
            S = s;
        }
        public string? S { get; set; }
    }

    public record AppTaskListByUserIdRequest : PagedRequest, IRequest<PagedResult<AppTaskListDto>>
    {
        public AppTaskListByUserIdRequest(int activePage, string s, int userId) : base(activePage)
        {
            S = s;
            UserId = userId;
        }
        public string? S { get; set; }
        public int UserId { get; set; }
    }

    public record AppTaskGetByIdRequest(int Id) : IRequest<Result<AppTaskListDto>>;

    public record AppTaskCreateRequest(string? Title, string? Description, int PriorityId) : IRequest<Result<AppTaskDto>>;

    public record AppTaskDeleteRequest(int Id) : IRequest<Result<NoData>>;

    public record AppTaskUpdateRequest(int Id,string? Title, string? Description, int PriorityId, int? AppUserId) : IRequest<Result<AppTaskDto>>;

    public record AppTaskCompleteRequest(int Id) : IRequest<Result<NoData>>;
}
