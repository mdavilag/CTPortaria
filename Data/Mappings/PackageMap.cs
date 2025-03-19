using CTPortaria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTPortaria.Data.Mappings
{
    public class PackageMap : IEntityTypeConfiguration<PackageModel>
    {
        public void Configure(EntityTypeBuilder<PackageModel> builder)
        {
            builder.ToTable("Packages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("text")
                .IsRequired()
                .HasMaxLength(120);
            builder.Property(x => x.ReceivedBy)
                .HasColumnName("ReceivedBy")
                .HasColumnType("VARCHAR(40)")
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.AdressedTo)
                .HasColumnName("AdressedTo")
                .HasColumnType("VARCHAR(40)")
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.ToSector)
                .HasColumnName("ToSector")
                .HasColumnType("VARCHAR(60)")
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(x => x.DeliveredTo)
                .HasColumnName("DeliveredTo")
                .HasColumnType("VARCHAR(40)")
                .HasMaxLength(40);
            builder.Property(x => x.DeliveredAt)
                .HasColumnName("DeliveredAt")
                .HasColumnType("Datetime");
            builder.Property(x => x.ReceivedAt)
                .HasColumnName("ReceivedAt")
                .HasColumnType("Datetime");
        }
    }
}
