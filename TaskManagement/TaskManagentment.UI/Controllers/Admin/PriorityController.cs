using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagentment.Application.Request;

namespace TaskManagentment.UI.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PriorityController : Controller
    {
        private readonly IMediator _mediator;
        public PriorityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> List()
        {
            var kar = await this._mediator.Send(new PriorityListRequest());
            return View(kar.Data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PriorityCreateRequest request)
        {
            return View();
        }
    }
}
