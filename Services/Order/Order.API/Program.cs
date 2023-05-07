using Order.Infostracture.DI;
using Order.Application.DI;
using Order.API.Middleware;
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

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

await app.MigrateDatabaseAsync();
await app.SeedDataAsync();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.UseCors();

app.Run();
