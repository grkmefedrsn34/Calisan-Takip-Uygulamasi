using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Request;

namespace TaskManagentment.UI.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new AccountRequest("", ""));
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountRequest dto)
        {
            var response = await _mediator.Send(dto);
            if (response.IsSuccess && response.Data != null)
            {
                await SetAuthCookie(response.Data, dto.rememberMe);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                if (response.Erorrs != null && response.Erorrs.Count > 0)
                {
                    foreach (var error in response.Erorrs)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErorrMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", response.ErrorMessage ?? "Bilinmeyen bir hata oluştu");
                }

                return View(dto);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistarRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (result.Erorrs != null && result.Erorrs.Count > 0)
                {
                    foreach (var error in result.Erorrs)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErorrMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "Bilinmeyen bir hata oluştu");
                }

                return View(request);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private async Task SetAuthCookie(LoginResponseDto dto, bool rememberMe)
        {
            var claims = new List<Claim>
            {
                new Claim("Name", dto.Name),
                new Claim("Surname", dto.Surname),
                new Claim(ClaimTypes.Role, dto.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
                IsPersistent = rememberMe
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}
