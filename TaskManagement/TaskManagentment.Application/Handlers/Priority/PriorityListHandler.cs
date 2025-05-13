using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Handlers
{
    public class PriorityListHandler :IRequestHandler<PriorityListRequest, Response<List<PriorityListDtos>>>
    {
        private readonly IPriorityRepository priorityRepository;

        public PriorityListHandler(IPriorityRepository Repository)
        {
            this.priorityRepository = Repository;
        }
        public async Task<Response<List<PriorityListDtos>>> Handle(PriorityListRequest request, CancellationToken cancellationToken)
        {
            var result = this.priorityRepository.GetAllAsync();
            var mapped = result.Result.Select(x => new PriorityListDtos(x.ID, x.Definition)).ToList();
            return new Response<List<PriorityListDtos>>(mapped, true,null, null);
            throw new NotImplementedException();
        }
    }
}
