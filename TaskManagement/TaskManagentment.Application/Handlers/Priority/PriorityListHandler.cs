using MediatR;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Handlers
{
    public class PriorityListHandler : IRequestHandler<PriorityListRequest, Response<List<PriorityListDtos>>>
    {
        private readonly IPriorityRepository priorityRepository;

        public PriorityListHandler(IPriorityRepository repository)
        {
            priorityRepository = repository;
        }

        public async Task<Response<List<PriorityListDtos>>> Handle(PriorityListRequest request, CancellationToken cancellationToken)
        {
            var result = await priorityRepository.GetAllAsync();

            var mapped = result.Select(x => new PriorityListDtos(x.ID, x.Definition)).ToList();

            return new Response<List<PriorityListDtos>>(mapped, true, null, null);
        }
    }
}
