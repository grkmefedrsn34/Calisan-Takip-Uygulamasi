using TaskManagement.Persistance;
using TaskManagentment.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// MVC ve Razor deste�i
builder.Services.AddControllersWithViews();

// Katman servisleri
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices(); // do�ru method ad�

var app = builder.Build();

// Static dosyalar (wwwroot vb.)
app.UseStaticFiles();

// Route ayarlar�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
