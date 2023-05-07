using Favorite.API.Middleware;
using Favorite.Application.DI;
using Favorite.Infostructure.DI;
using Order.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(x => x.WithOrigins("http://localhost:50000", "http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
});

builder.Services.AddControllers();

builder.Services.ApplicationConfigure();
builder.Services.InfostructureConfigure(builder.Configuration);

var app = builder.Build();

await app.MigrateDatabaseAsync();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.UseCors();

app.Run();
