using MediatR;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Extensions;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;
using TaskManagentment.Application.Validation.Priority;

namespace TaskManagentment.Application.Handlers.Priority
{
    public class PriorityCreateHandler : IRequestHandler<PriorityCreateRequest, Response<NoData>>
    {
        private readonly IPriorityRepository Repository;

        public PriorityCreateHandler(IPriorityRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<Response<NoData>> Handle(PriorityCreateRequest request, CancellationToken cancellationToken)
        {
            var validation = new PriorityCreateRequestValidation();
            var validationResult = await validation.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var entity = request.ToMap(); // Priority entity
                var result = await Repository.CreateAsync(entity);

                if (result > 0)
                {
                    return new Response<NoData>(new NoData(), true, null, null);
                }
                else
                {
                    return new Response<NoData>(new NoData(), false, "Priority not created", null);
                }
            }
            else
            {
                var errorList = validationResult.Errors.ToMap();
                return new Response<NoData>(new NoData(), false, null, errorList);
            }
        }
    }
}
