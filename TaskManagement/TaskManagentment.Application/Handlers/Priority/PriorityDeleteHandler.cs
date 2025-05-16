using MediatR;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Interfaces;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Handlers.Priority
{
    public class PriorityDeleteHandler :IRequestHandler<PriorityDeleteRequest, Response<NoData>>
    {
        private readonly IPriorityRepository Repository;
        public PriorityDeleteHandler(IPriorityRepository repository)
        {
            this.Repository = repository;
        }
        public async Task<Response<NoData>> Handle(PriorityDeleteRequest request, CancellationToken cancellationToken)
        {
            var deleteEntitit = await this.Repository.GetByFilterAsync(x => x.ID == request.ID);
            if (deleteEntitit != null)
            {
                await this.Repository.DeleteAsync(deleteEntitit);
                return new Response<NoData>(new NoData(), true,null,null);
            }
            return new Response<NoData>(new NoData(), false, "null", null);
        }
    }
}
