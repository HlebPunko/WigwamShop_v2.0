using Catalog.Infostructure.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InfostructureConfigure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
