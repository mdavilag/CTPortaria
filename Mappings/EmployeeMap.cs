using System.Xml.XPath;
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
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.HasIndex(x => x.Name)
                .IsUnique()
                .HasDatabaseName("IX_Employee_Name");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(80)")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("VARCHAR(11)")
                .HasMaxLength(11);
            builder.HasIndex(x => x.Cpf)
                .IsUnique();

            builder.Property(x => x.JobRole)
                .HasColumnName("JobRole")
                .HasColumnType("VARCHAR(40)")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .IsRequired();
            builder.HasMany(x => x.GateLogs)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId)
                .HasConstraintName("FK_GateLogs_EmployeeId");
        }
    }
}
