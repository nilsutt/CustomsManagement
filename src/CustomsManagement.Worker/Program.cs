using CustomsManagement.Application.Extentions;
using CustomsManagement.Infrastructure.Extentions;
using CustomsManagement.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ShipmentWorker>();

builder.Services.AddInfrastructureEFRepositories(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddApplicationServices();

var host = builder.Build();
host.Run();