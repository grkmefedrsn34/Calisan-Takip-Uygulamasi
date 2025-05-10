using TaskManagement.Persistance;
using TaskManagentment.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// MVC ve Razor desteði
builder.Services.AddControllersWithViews();

// Katman servisleri
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices(); // doðru method adý

var app = builder.Build();

// Static dosyalar (wwwroot vb.)
app.UseStaticFiles();

// Route ayarlarý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
