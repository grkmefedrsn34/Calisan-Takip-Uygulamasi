using TaskManagement.Persistance;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddPersistanceServices(builder.Configuration);

app.MapGet("/", () => "Hello World!");

app.Run();
