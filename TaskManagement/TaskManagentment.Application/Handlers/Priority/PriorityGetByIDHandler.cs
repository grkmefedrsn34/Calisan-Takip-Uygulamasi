using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Handlers.Priority
{
    class PriorityGetByIDHandler: IRequestHandler<PriorityGetByIDRequest, Response<PriorityListDtos>>
    {
        private readonly IPriorityRepository Repository;

        public PriorityGetByIDHandler(IPriorityRepository repository)
        {
            this.Repository = repository;
        }
        public async Task<Response<PriorityListDtos>> Handle(PriorityGetByIDRequest request, CancellationToken cancellationToken)
        {
            var priority = await this.Repository.GetByFilterAsNoTrackingAsync(x => x.ID == request.ID);
            if (priority != null)
            {
                return new  Response<PriorityListDtos>(new PriorityListDtos(priority.ID, priority.Definition), true, null, null);
            }
            return new Response<PriorityListDtos>(new PriorityListDtos(0, ""), false, "Aciliyet Bulunamadı", null);
        }
    }
}
