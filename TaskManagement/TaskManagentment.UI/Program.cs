using Microsoft.AspNetCore.Authentication.Cookies;
using TaskManagement.Persistance;
using TaskManagentment.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
    {
        opt.Cookie.Name = "LoginCookie"; // Cookie ad�
        opt.Cookie.HttpOnly = true; // HttpOnly �zelli�i
        opt.Cookie.SameSite = SameSiteMode.Strict; // SameSite �zelli�i
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Secure �zelli�i
    });

// MVC ve Razor deste�i
builder.Services.AddControllersWithViews();

// Katman servisleri
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices(); // do�ru method ad�

var app = builder.Build();

// Static dosyalar (wwwroot vb.)
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

// Route ayarlar�

app.MapControllerRoute(name: "area",pattern: "{Area}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(name: "default",pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
