﻿// <auto-generated />
using System;
using CTPortaria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CTPortaria.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CTPortaria.Entities.EmployeeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("Cpf");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("JobRole")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR(40)")
                        .HasColumnName("JobRole");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("CTPortaria.Entities.GateLogModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("Datetime")
                        .HasColumnName("CreatedAt");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnteredAt")
                        .HasColumnType("Datetime")
                        .HasColumnName("EnteredAt");

                    b.Property<DateTime?>("LeavedAt")
                        .HasColumnType("Datetime")
                        .HasColumnName("LeavedAt");

                    b.Property<string>("VisitorIdentity")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("VisitorIdentity");

                    b.Property<string>("VisitorName")
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("VisitorName");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("GateLogs", (string)null);
                });

            modelBuilder.Entity("CTPortaria.Entities.PackageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdressedTo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR(40)")
                        .HasColumnName("AdressedTo");

                    b.Property<DateTime?>("DeliveredAt")
                        .HasColumnType("Datetime")
                        .HasColumnName("DeliveredAt");

                    b.Property<string>("DeliveredTo")
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR(40)")
                        .HasColumnName("DeliveredTo");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("Datetime")
                        .HasColumnName("ReceivedAt");

                    b.Property<string>("ReceivedBy")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR(40)")
                        .HasColumnName("ReceivedBy");

                    b.Property<string>("ToSector")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)")
                        .HasColumnName("ToSector");

                    b.HasKey("Id");

                    b.ToTable("Packages", (string)null);
                });

            modelBuilder.Entity("CTPortaria.Entities.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivedAt")
                        .HasColumnType("Datetime")
                        .HasColumnName("ArrivedAt");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR(40)")
                        .HasColumnName("CarModel");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR(40)")
                        .HasColumnName("Category");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("CompanyName");

                    b.Property<string>("DriversIdentity")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("DriversIdentity");

                    b.Property<string>("DriversName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("DriversName");

                    b.Property<string>("Invoice")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("Invoice");

                    b.Property<DateTime>("LeavedAt")
                        .HasColumnType("Datetime")
                        .HasColumnName("LeavedAt");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnName("LicensePlace");

                    b.Property<string>("ReceivedBy")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)")
                        .HasColumnName("ReceivedBy");

                    b.Property<string>("ToSector")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)")
                        .HasColumnName("ToSector");

                    b.HasKey("Id");

                    b.ToTable("Vehicles", (string)null);
                });

            modelBuilder.Entity("CTPortaria.Entities.GateLogModel", b =>
                {
                    b.HasOne("CTPortaria.Entities.EmployeeModel", "Employee")
                        .WithMany("GateLogs")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_GateLogs_EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CTPortaria.Entities.EmployeeModel", b =>
                {
                    b.Navigation("GateLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
