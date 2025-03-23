using CTPortaria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTPortaria.Data.Mappings
{
    public class VisitorMap : IEntityTypeConfiguration<VisitorModel>
    {
        public void Configure(EntityTypeBuilder<VisitorModel> builder)
        {
            builder.ToTable("Visitors");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.HasIndex(x => x.Cpf)
                .IsUnique()
                .HasDatabaseName("IX_Visitors_Cpf");
            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(80)")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("VARCHAR(11)")
                .HasMaxLength(11);
            builder.Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50);

            builder.HasMany(x => x.GateLogs)
                .WithOne(x => x.Visitor)
                .HasForeignKey(x => x.VisitorId)
                .HasConstraintName("FK_GateLogs_VisitorId");
        }
    }
}
