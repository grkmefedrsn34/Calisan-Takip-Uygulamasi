using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public async Task<IActionResult> Create(PriorityCreateRequest request)
        {
            var result = await this._mediator.Send(request);
            if(result.IsSuccess)
            {
                return RedirectToAction("List");
            }
            else
            {
                if (result.Erorrs?.Count > 0)
                {
                    foreach (var erorrs in result.Erorrs)
                    {
                        ModelState.AddModelError(erorrs.PropertyName, erorrs.ErorrMessage);
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("",result.ErrorMessage ?? "Bir hata oluştu");
                }
            }
            return View(request);
        }
            
        public async Task<IActionResult> Delete(int id)
        {   
                await this._mediator.Send(new PriorityDeleteRequest(id));
                return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await this._mediator.Send(new PriorityGetByIDRequest(id));
            if(result.IsSuccess)
            {
                var requestModel = new PriorityUpdateRequest(result.Data.ID, result.Data.Definition);
                return View(result.Data);
            }
            else
            {
                 ModelState.AddModelError("", result.ErrorMessage ?? "Bir hata oluştu");
                var requestModel = new PriorityUpdateRequest(0,null);
                return View(requestModel);
            }
        }
    }
}
