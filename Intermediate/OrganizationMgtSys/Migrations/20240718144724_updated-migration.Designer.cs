﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrganizationMgtSys.DataAccess.DataContext;

#nullable disable

namespace OrganizationMgtSys.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240718144724_updated-migration")]
    partial class updatedmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Appraisal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AppraisalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppraisalMonth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EvaluationMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Appraisals");
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.CheckIn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("CheckinTime")
                        .HasColumnType("time");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("StaffCheckIns");
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Checkout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("CheckoutTime")
                        .HasColumnType("time");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("StaffCheckOuts");
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AddressID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("StandardCheckOutTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StandardCheckinTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("AddressID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Query", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Queries");
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Staff"
                        });
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsClockedIn")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("StaffUniqueNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("AddressID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("RoleId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Appraisal", b =>
                {
                    b.HasOne("OrganizationMgtSys.Domain.Models.Staff", null)
                        .WithMany("Appraisals")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.CheckIn", b =>
                {
                    b.HasOne("OrganizationMgtSys.Domain.Models.Staff", null)
                        .WithMany("CheckIns")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Checkout", b =>
                {
                    b.HasOne("OrganizationMgtSys.Domain.Models.Staff", null)
                        .WithMany("CheckOuts")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Company", b =>
                {
                    b.HasOne("OrganizationMgtSys.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Query", b =>
                {
                    b.HasOne("OrganizationMgtSys.Domain.Models.Staff", null)
                        .WithMany("Queries")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Staff", b =>
                {
                    b.HasOne("OrganizationMgtSys.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.HasOne("OrganizationMgtSys.Domain.Models.Company", null)
                        .WithMany("Staffs")
                        .HasForeignKey("CompanyID");

                    b.HasOne("OrganizationMgtSys.Domain.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Company", b =>
                {
                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("OrganizationMgtSys.Domain.Models.Staff", b =>
                {
                    b.Navigation("Appraisals");

                    b.Navigation("CheckIns");

                    b.Navigation("CheckOuts");

                    b.Navigation("Queries");
                });
#pragma warning restore 612, 618
        }
    }
}