﻿// <auto-generated />
using System;
using AssetManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssetManagement.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("AssetManagement.Models.Asset", b =>
                {
                    b.Property<string>("TelephoneSerialNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ExtensionNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("InstalledDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TelephoneSerialNo", "ExtensionNumber");

                    b.HasIndex("ExtensionNumber");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("AssetManagement.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("AssetManagement.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("AssetManagement.Models.Employee", b =>
                {
                    b.Property<int>("BadgeNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BadgeNo");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("AssetManagement.Models.Extension", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("EmployeeBadgeNo")
                        .HasColumnType("int");

                    b.Property<int>("Usage")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("EmployeeBadgeNo");

                    b.ToTable("Extension");
                });

            modelBuilder.Entity("AssetManagement.Models.OtherAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeBadgeNo")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeBadgeNo");

                    b.ToTable("OtherAsset");
                });

            modelBuilder.Entity("AssetManagement.Models.Pager", b =>
                {
                    b.Property<string>("SerialNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Capcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cust")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeBadgeNo")
                        .HasColumnType("int");

                    b.Property<string>("Facility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("RateCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("SerialNo");

                    b.HasIndex("EmployeeBadgeNo");

                    b.ToTable("Pager");
                });

            modelBuilder.Entity("AssetManagement.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("AssetManagement.Models.Telephone", b =>
                {
                    b.Property<string>("SerialNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MAC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SerialNo");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Telephone");
                });

            modelBuilder.Entity("AssetManagement.Models.Asset", b =>
                {
                    b.HasOne("AssetManagement.Models.Extension", "Extension")
                        .WithMany("Assets")
                        .HasForeignKey("ExtensionNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssetManagement.Models.Telephone", "Telephone")
                        .WithMany("Assets")
                        .HasForeignKey("TelephoneSerialNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Extension");

                    b.Navigation("Telephone");
                });

            modelBuilder.Entity("AssetManagement.Models.Employee", b =>
                {
                    b.HasOne("AssetManagement.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AssetManagement.Models.Extension", b =>
                {
                    b.HasOne("AssetManagement.Models.Employee", "Employee")
                        .WithMany("Extensions")
                        .HasForeignKey("EmployeeBadgeNo");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AssetManagement.Models.OtherAsset", b =>
                {
                    b.HasOne("AssetManagement.Models.Employee", "Employee")
                        .WithMany("OtherAssets")
                        .HasForeignKey("EmployeeBadgeNo");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AssetManagement.Models.Pager", b =>
                {
                    b.HasOne("AssetManagement.Models.Employee", "Employee")
                        .WithMany("Pagers")
                        .HasForeignKey("EmployeeBadgeNo");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AssetManagement.Models.SubCategory", b =>
                {
                    b.HasOne("AssetManagement.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AssetManagement.Models.Telephone", b =>
                {
                    b.HasOne("AssetManagement.Models.SubCategory", "SubCategory")
                        .WithMany("Telephones")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("AssetManagement.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("AssetManagement.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AssetManagement.Models.Employee", b =>
                {
                    b.Navigation("Extensions");

                    b.Navigation("OtherAssets");

                    b.Navigation("Pagers");
                });

            modelBuilder.Entity("AssetManagement.Models.Extension", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("AssetManagement.Models.SubCategory", b =>
                {
                    b.Navigation("Telephones");
                });

            modelBuilder.Entity("AssetManagement.Models.Telephone", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
