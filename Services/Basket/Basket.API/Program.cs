using Basket.API.Extensions;
using Basket.Infostructure.DI;
using Basket.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ApplicationConfigure();
builder.Services.InfostructureConfigure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

await app.MigrateDatabaseAsync();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();

