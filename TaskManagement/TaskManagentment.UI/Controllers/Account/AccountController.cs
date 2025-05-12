using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagentment.Application.DTOs;
using TaskManagentment.Application.Request;
using System.Threading.Tasks;

namespace TaskManagentment.UI.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        [HttpPost]
        public IActionResult Login()
        {
            return View(new AccountRequest("",""));
        }

        // Custom cookie  based auth
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
                    return View(dto);
                }
            }
            return View();
        }

        [HttpGet]
        public  IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register( RegistarRequest request)
        {
            var result =  await _mediator.Send(request);
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
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private  async Task SetAuthCookie(LoginResponseData? dto , bool rememberMe)
        {
            User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name);

            var claims = new List<Claim>
        {
            new Claim("Name", dto.Name),
            new Claim("Surname", dto.Surname),
            new Claim(ClaimTypes.Role, dto.role.ToString()),
        };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = rememberMe,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

        }
    }
}
