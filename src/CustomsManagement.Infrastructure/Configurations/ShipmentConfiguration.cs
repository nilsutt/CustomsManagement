using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomsManagement.Domain.Entities.Aggregates;

namespace CustomsManagement.Infrastructure.Configurations
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("Shipments");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(s => s.ImporterExporterName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.ProductType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.DeclaredValue)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Tax)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.CreatedDate)
                .IsRequired();
        }
    }
}