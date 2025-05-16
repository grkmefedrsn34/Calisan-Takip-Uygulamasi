using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagentment.Application.Request;
using TaskManagetment.Domain.Entities;

namespace TaskManagentment.UI.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AppTaskController : Controller
    {
        private readonly IMediator Mediator;
        public AppTaskController(IMediator mediator)
        {
            Mediator = mediator;
        }
        public async Task <IActionResult> List(int activePage=1)
        {
            var result = await Mediator.Send(new AppTaskListRequest(activePage));
            return View();
        }
    }
}
