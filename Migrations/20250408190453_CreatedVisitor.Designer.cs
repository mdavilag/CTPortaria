﻿// <auto-generated />
using System;
using CTPortaria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CTPortaria.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250408190453_CreatedVisitor")]
    partial class CreatedVisitor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
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

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Employee_Name");

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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnteredAt")
                        .HasColumnType("Datetime")
                        .HasColumnName("EnteredAt");

                    b.Property<DateTime?>("LeavedAt")
                        .HasColumnType("Datetime")
                        .HasColumnName("LeavedAt");

                    b.Property<string>("RegisteredBy")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("RegisteredBy");

                    b.Property<int?>("VisitorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VisitorId");

                    b.ToTable("GateLogs", (string)null);
                });

            modelBuilder.Entity("CTPortaria.Entities.VisitorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR(50)")
                        .HasColumnName("CompanyName");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasDatabaseName("IX_Visitors_Cpf");

                    b.ToTable("Visitors", (string)null);
                });

            modelBuilder.Entity("CTPortaria.Entities.GateLogModel", b =>
                {
                    b.HasOne("CTPortaria.Entities.EmployeeModel", "Employee")
                        .WithMany("GateLogs")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_GateLogs_EmployeeId");

                    b.HasOne("CTPortaria.Entities.VisitorModel", "Visitor")
                        .WithMany("GateLogs")
                        .HasForeignKey("VisitorId")
                        .HasConstraintName("FK_GateLogs_VisitorId");

                    b.Navigation("Employee");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("CTPortaria.Entities.EmployeeModel", b =>
                {
                    b.Navigation("GateLogs");
                });

            modelBuilder.Entity("CTPortaria.Entities.VisitorModel", b =>
                {
                    b.Navigation("GateLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
