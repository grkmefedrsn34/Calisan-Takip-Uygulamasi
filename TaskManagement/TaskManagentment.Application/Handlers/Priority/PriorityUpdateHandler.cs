using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Extensions;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;
using TaskManagentment.Application.Validation.Priority;

namespace TaskManagentment.Application.Handlers.Priority
{
    public class PriorityUpdateHandler : IRequestHandler<PriorityUpdateRequest, Response<NoData>>
    {
        private readonly IPriorityRepository Repository;
        public PriorityUpdateHandler(IPriorityRepository repository)
        {
            Repository = repository;
        }
        public async Task<Response<NoData>> Handle(PriorityUpdateRequest request, CancellationToken cancellationToken)
        {
             var value = new PriorityUpdateRequestValidation();
            var result = await value.ValidateAsync(request);

            if (result.IsValid)
            {
                var updateEntitiy = await this.Repository.GetByFilterAsync(x => x.ID == request.ID);
                if (updateEntitiy == null)
                {
                    return new Response<NoData>(new NoData(), false, "Priority Not Found", null);
                }
                updateEntitiy.Definition = request.Definition ?? "";

                await this.Repository.SaveChangeAsync();
                return new Response<NoData>(new NoData(), true, null, null);
            }
            else
            {
                var errors = result.Errors.ToMap();
                return new Response<NoData>(new NoData(), false, null, errors);
            }  
        }
    }
}
