using CTPortaria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTPortaria.Data.Mappings
{
    public class GateLogMap : IEntityTypeConfiguration<GateLogModel>
    {
        public void Configure(EntityTypeBuilder<GateLogModel> builder)
        {
            builder.ToTable("GateLogs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.VisitorName)
                .HasColumnName("VisitorName")
                .HasColumnType("VARCHAR(80)")
                .HasMaxLength(80);
            builder.Property(x => x.VisitorIdentity)
                .HasColumnName("VisitorIdentity")
                .HasColumnType("VARCHAR(20)")
                .HasMaxLength(20);
            builder.Property(x => x.EnteredAt)
                .HasColumnName("EnteredAt")
                .HasColumnType("Datetime")
                .IsRequired();

            builder.Property(x => x.LeavedAt)
                .HasColumnName("LeavedAt")
                .HasColumnType("Datetime");
            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("Datetime")
                .IsRequired();
            builder.Property(x => x.RegisteredBy)
                .HasColumnName("RegisteredBy")
                .HasColumnType("VARCHAR(80)")
                .IsRequired();
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.GateLogs)
                .HasForeignKey(x => x.EmployeeId)
                .HasConstraintName("FK_GateLogs_EmployeeId");
        }
    }
}
