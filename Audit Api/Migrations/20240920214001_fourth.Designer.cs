﻿// <auto-generated />
using System;
using Audit_Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Audit_Api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240920214001_fourth")]
    partial class fourth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Audit_Api.Models.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("UserID");

                    b.ToTable("Audits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Action = "Create",
                            EmployeeID = 1,
                            Timestamp = new DateTime(2024, 9, 21, 1, 39, 59, 133, DateTimeKind.Local).AddTicks(5637),
                            UserID = 1
                        },
                        new
                        {
                            Id = 2,
                            Action = "Update",
                            EmployeeID = 2,
                            Timestamp = new DateTime(2024, 9, 21, 1, 39, 59, 133, DateTimeKind.Local).AddTicks(5653),
                            UserID = 2
                        },
                        new
                        {
                            Id = 3,
                            Action = "Delete",
                            EmployeeID = 3,
                            Timestamp = new DateTime(2024, 9, 21, 1, 39, 59, 133, DateTimeKind.Local).AddTicks(5656),
                            UserID = 3
                        });
                });

            modelBuilder.Entity("Audit_Api.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "HR"
                        },
                        new
                        {
                            Id = 2,
                            Name = "IT"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Finance"
                        });
                });

            modelBuilder.Entity("Audit_Api.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentID = 1,
                            Name = "Alice",
                            Position = "Manager"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentID = 2,
                            Name = "Bob",
                            Position = "Developer"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentID = 3,
                            Name = "Charlie",
                            Position = "Analyst"
                        });
                });

            modelBuilder.Entity("Audit_Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User1"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User2"
                        });
                });

            modelBuilder.Entity("Audit_Api.Models.Audit", b =>
                {
                    b.HasOne("Audit_Api.Models.Employee", "Employee")
                        .WithMany("Audits")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Audit_Api.Models.User", "User")
                        .WithMany("Audits")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Audit_Api.Models.Employee", b =>
                {
                    b.HasOne("Audit_Api.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Audit_Api.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Audit_Api.Models.Employee", b =>
                {
                    b.Navigation("Audits");
                });

            modelBuilder.Entity("Audit_Api.Models.User", b =>
                {
                    b.Navigation("Audits");
                });
#pragma warning restore 612, 618
        }
    }
}
