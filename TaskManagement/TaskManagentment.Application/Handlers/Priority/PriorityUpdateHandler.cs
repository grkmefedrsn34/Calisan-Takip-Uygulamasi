using MediatR;
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
            var validator = new PriorityUpdateRequestValidation();
            var result = await validator.ValidateAsync(request);

            if (result.IsValid)
            {
                var updateEntity = await Repository.GetByFilterAsync(x => x.ID == request.ID);
                if (updateEntity == null)
                {
                    return new Response<NoData>(
                        new NoData(),
                        false,
                        "Priority Not Found",
                        null
                    );
                }

                updateEntity.Definition = request.Definition ?? "";

                await Repository.SaveChangeAsync();

                return new Response<NoData>(
                    new NoData(),
                    true,
                    null,
                    null
                );
            }
            else
            {
                var errors = result.Errors.ToMap();

                return new Response<NoData>(
                    new NoData(),
                    false,
                    null,
                    errors
                );
            }
        }
    }
}
