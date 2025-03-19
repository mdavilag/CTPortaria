using CTPortaria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTPortaria.Data.Mappings
{
    public class VehicleMap : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("VARCHAR(80)")
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(x => x.Invoice)
                .HasColumnName("Invoice")
                .HasColumnType("VARCHAR(20)")
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.DriversName)
                .HasColumnName("DriversName")
                .HasColumnType("VARCHAR(80)")
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(x => x.DriversIdentity)
                .HasColumnName("DriversIdentity")
                .HasColumnType("VARCHAR(20)")
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.LicensePlate)
                .HasColumnName("LicensePlace")
                .HasColumnType("VARCHAR(10)")
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(x => x.CarModel)
                .HasColumnName("CarModel")
                .HasColumnType("VARCHAR(40)")
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.ToSector)
                .HasColumnName("ToSector")
                .HasColumnType("VARCHAR(60)")
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(x => x.Category)
                .HasColumnName("Category")
                .HasColumnType("VARCHAR(40)")
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.ReceivedBy)
                .HasColumnName("ReceivedBy")
                .HasColumnType("VARCHAR(60)")
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(x => x.ArrivedAt)
                .HasColumnName("ArrivedAt")
                .HasColumnType("Datetime")
                .IsRequired();
            builder.Property(x => x.LeavedAt)
                .HasColumnName("LeavedAt")
                .HasColumnType("Datetime");
        }
    }
}
