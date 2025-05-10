using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Request;

namespace TaskManagentment.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AccountRequest dto)
        {
             var response = await this._mediator.Send(dto);
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
