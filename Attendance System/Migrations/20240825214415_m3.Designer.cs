﻿// <auto-generated />
using System;
using Attendance_System.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Attendance_System.Migrations
{
    [DbContext(typeof(ITIContext))]
    [Migration("20240825214415_m3")]
    partial class m3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Attendance_System.Models.Attendance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Attended")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("Attendance_System.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Attendance_System.Models.Intake", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProgramID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProgramID");

                    b.ToTable("Intakes");
                });

            modelBuilder.Entity("Attendance_System.Models.Program", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Attendance_System.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IntakeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Verified")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("IntakeID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DepartmentIntake", b =>
                {
                    b.Property<int>("DepartmentsID")
                        .HasColumnType("int");

                    b.Property<int>("IntakesID")
                        .HasColumnType("int");

                    b.HasKey("DepartmentsID", "IntakesID");

                    b.HasIndex("IntakesID");

                    b.ToTable("DepartmentIntake");
                });

            modelBuilder.Entity("Attendance_System.Models.Intake", b =>
                {
                    b.HasOne("Attendance_System.Models.Program", null)
                        .WithMany("Intakes")
                        .HasForeignKey("ProgramID");
                });

            modelBuilder.Entity("Attendance_System.Models.User", b =>
                {
                    b.HasOne("Attendance_System.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentID");

                    b.HasOne("Attendance_System.Models.Intake", "Intake")
                        .WithMany()
                        .HasForeignKey("IntakeID");

                    b.Navigation("Department");

                    b.Navigation("Intake");
                });

            modelBuilder.Entity("DepartmentIntake", b =>
                {
                    b.HasOne("Attendance_System.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attendance_System.Models.Intake", null)
                        .WithMany()
                        .HasForeignKey("IntakesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attendance_System.Models.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Attendance_System.Models.Program", b =>
                {
                    b.Navigation("Intakes");
                });
#pragma warning restore 612, 618
        }
    }
}
