using CTPortaria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTPortaria.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<EmployeeModel>
    {
        public void Configure(EntityTypeBuilder<EmployeeModel> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(80)")
                .HasMaxLength(80);

            builder.Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("VARCHAR(11)")
                .HasMaxLength(11);
            builder.Property(x => x.JobRole)
                .HasColumnName("JobRole")
                .HasColumnType("VARCHAR(40)")
                .HasMaxLength(40);
            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit");
            builder.HasMany(x => x.GateLogs)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId)
                .HasConstraintName("FK_GateLogs_EmployeeId");
        }
    }
}
