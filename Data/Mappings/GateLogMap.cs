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
            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("TEXT")
                .HasMaxLength(300);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.GateLogs)
                .HasForeignKey(x => x.EmployeeId)
                .HasConstraintName("FK_GateLogs_EmployeeId");
            builder.HasOne(x => x.Visitor)
                .WithMany(x => x.GateLogs)
                .HasForeignKey(x => x.VisitorId)
                .HasConstraintName("FK_Gatelogs_VisitorId");
        }
    }
}
