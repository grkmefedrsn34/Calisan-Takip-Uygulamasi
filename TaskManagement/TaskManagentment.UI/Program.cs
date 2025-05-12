using Microsoft.AspNetCore.Authentication.Cookies;
using TaskManagement.Persistance;
using TaskManagentment.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
    {
        opt.Cookie.Name = "LoginCookie"; // Cookie adý
        opt.Cookie.HttpOnly = true; // HttpOnly özelliði
        opt.Cookie.SameSite = SameSiteMode.Strict; // SameSite özelliði
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Secure özelliði
    });

// MVC ve Razor desteði
builder.Services.AddControllersWithViews();

// Katman servisleri
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices(); // doðru method adý

var app = builder.Build();

// Static dosyalar (wwwroot vb.)
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

// Route ayarlarý

app.MapControllerRoute(name: "area",pattern: "{Area}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default",pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
