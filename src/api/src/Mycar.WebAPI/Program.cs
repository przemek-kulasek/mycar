using Mycar.WebAPI.Endpoints;
using Mycar.WebAPI.Startup.Application;
using Mycar.WebAPI.Startup.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterSwagger();
builder.Services.RegisterDependencyInjection();
builder.Services.AddModules(builder.Configuration);
builder.Services.AddHostedServices();

var app = builder.Build();
app.ConfigureSwagger();
app.UseHttpsRedirection();
app.MapCarsEndpoints();
app.MapOperationsEndpoints();
app.MapItemsEndpoints();
app.ConfigureMiddlewares();
app.Run();
