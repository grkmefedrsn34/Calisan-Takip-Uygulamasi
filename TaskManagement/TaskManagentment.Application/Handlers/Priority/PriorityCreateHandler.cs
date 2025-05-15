using MediatR;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Extensions;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;
using TaskManagentment.Application.Validation.Priority;


namespace TaskManagentment.Application.Handlers.Priority
{
    public class PriorityCreateHandler: IRequestHandler<PriorityCreateRequest, Response<NoData>>
    {
        private readonly IPriorityRepository Repository;
        public PriorityCreateHandler(IPriorityRepository repository)
        {
            this.Repository = repository;
        }

       
        public async Task<Response<NoData>> Handle(PriorityCreateRequest request, CancellationToken cancellationToken)
        {
            var value =  new PriorityCreateRequestValidation();
            var valuede = value.Validate(request);

            if (valuede.IsValid)
            {
                var rowCount = await this.Repository.CreateAsync(request.ToMap());
                if (rowCount > 0)
                {
                    return new Response<NoData>(new NoData(), true, null, null);
                }
                return new Response<NoData>(new NoData(), false, "Sistemsel bir hata oluştu ", null);
            }
            else {
               var errors =  valuede.Errors.ToMap();
                return new Response<NoData>(new NoData(), false, null, errors);
            }
        }
    }
}
