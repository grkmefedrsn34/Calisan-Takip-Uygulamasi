using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Handlers.AppTask
{
    public class AppTaskListHandler : IRequestHandler<AppTaskListRequest, PagedResult<AppTaskListDto>>
    {
        private readonly IAppTaskRepository _repository;

        public AppTaskListHandler(IAppTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<AppTaskListDto>> Handle(AppTaskListRequest request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetAllAsync(request.ActivePage);

            var result = new List<AppTaskListDto>();

            foreach (var appTask in list.Data)
            {
                if (appTask == null) continue;

                var dto = new AppTaskListDto(
                    appTask.ID,
                    appTask.Title,
                    appTask.Description,
                    appTask?.Priority?.Definition,
                    appTask?.State
                );

                result.Add(dto);
            }

            return new PagedResult<AppTaskListDto>(
                result,
                request.ActivePage,
                list.PageSize,
                list.PageCount
            );
        }
    }
}
