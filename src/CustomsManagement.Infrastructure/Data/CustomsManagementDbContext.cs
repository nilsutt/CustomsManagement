using System.Reflection;
using CustomsManagement.Domain.Entities.Aggregates;
using CustomsManagement.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CustomsManagement.Infrastructure.Data;

public class CustomsManagementDbContext : DbContext
{
    public CustomsManagementDbContext(DbContextOptions<CustomsManagementDbContext> options) : base(options)
    {
    }

    public DbSet<Shipment> Shipments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ShipmentConfiguration());
    }
}