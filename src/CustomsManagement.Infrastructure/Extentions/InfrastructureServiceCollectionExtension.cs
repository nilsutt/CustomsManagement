using CustomsManagement.Domain.Interfaces;
using CustomsManagement.Infrastructure.Data;
using CustomsManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CustomsManagement.Infrastructure.Extentions;

public static class InfrastructureServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureEFRepositories(
        this IServiceCollection services,
        string connectionString)
    {
        // Register DbContext with the provided connection string
        services.AddDbContext<CustomsManagementDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Register generic repository
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        return services;
    }

    public static void MigrateDatabase(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<CustomsManagementDbContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            // Log the error or handle it accordingly
            Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
            throw;
        }
    }
}