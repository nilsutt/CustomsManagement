using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace CustomsManagement.Application.Extentions;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}