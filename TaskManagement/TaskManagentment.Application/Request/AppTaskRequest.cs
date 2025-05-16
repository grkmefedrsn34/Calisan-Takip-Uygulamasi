using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.DTOs;

namespace TaskManagentment.Application.Request
{
    public record AppTaskListRequest : PagedRequest ,IRequest<PagedResult<AppTaskListDto>>
    {
        public AppTaskListRequest(int activePage) : base(activePage)
        {
            ActivePage = activePage;
        }
        public int ActivePage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

