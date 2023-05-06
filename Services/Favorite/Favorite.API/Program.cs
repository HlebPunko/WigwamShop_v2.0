using Favorite.API.Middleware;
using Favorite.Application.DI;
using Favorite.Infostructure.DI;
using Order.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.ApplicationConfigure();
builder.Services.InfostructureConfigure(builder.Configuration);

var app = builder.Build();

await app.MigrateDatabaseAsync();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
