﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore_API.Data;

#nullable disable

namespace NetCoreAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230217073704_update_Account")]
    partial class updateAccount
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NetCore_API.Entity.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("NetCore_API.Entity.Asset", b =>
                {
                    b.Property<int>("Asset_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Asset_Id"));

                    b.Property<string>("Asset_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Asset_Id");

                    b.ToTable("Assets", (string)null);
                });

            modelBuilder.Entity("NetCore_API.Entity.Assignment", b =>
                {
                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<int>("Asset_Id")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id", "Asset_Id");

                    b.HasIndex("Asset_Id");

                    b.ToTable("Assugnments", (string)null);
                });

            modelBuilder.Entity("NetCore_API.Entity.Department", b =>
                {
                    b.Property<int>("Depart_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Depart_Id"));

                    b.Property<string>("Depart_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Depart_Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("NetCore_API.Entity.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<DateTime>("DateOfbirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Depart_Id")
                        .HasColumnType("int");

                    b.Property<string>("Number_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Id");

                    b.HasIndex("Depart_Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("NetCore_API.Entity.Assignment", b =>
                {
                    b.HasOne("NetCore_API.Entity.Asset", "Asset")
                        .WithMany("Assignments")
                        .HasForeignKey("Asset_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetCore_API.Entity.User", "User")
                        .WithMany("Assignments")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NetCore_API.Entity.User", b =>
                {
                    b.HasOne("NetCore_API.Entity.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("Depart_Id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("NetCore_API.Entity.Asset", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("NetCore_API.Entity.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("NetCore_API.Entity.User", b =>
                {
                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}