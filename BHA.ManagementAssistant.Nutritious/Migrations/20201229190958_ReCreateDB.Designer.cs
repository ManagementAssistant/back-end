﻿// <auto-generated />
using System;
using BHA.ManagementAssistant.Nutritious.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BHA.ManagementAssistant.Nutritious.WebApi.Migrations
{
    [DbContext(typeof(ManagementAssistantContext))]
    [Migration("20201229190958_ReCreateDB")]
    partial class ReCreateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BHA.ManagementAssistant.Nutritious.Model.Entity.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HierarchyTypeEnum")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BHA.ManagementAssistant.Nutritious.Model.Model.Entity.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedByUserID")
                        .HasColumnType("int");

                    b.Property<int?>("DeletedByUserID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedByUserID")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CreatedByUserID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("BHA.ManagementAssistant.Nutritious.Model.Model.Entity.Organization", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isHierarchical")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("BHA.ManagementAssistant.Nutritious.Model.Entity.User", b =>
                {
                    b.HasOne("BHA.ManagementAssistant.Nutritious.Model.Model.Entity.Organization", "Organization")
                        .WithMany("User")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BHA.ManagementAssistant.Nutritious.Model.Model.Entity.Company", b =>
                {
                    b.HasOne("BHA.ManagementAssistant.Nutritious.Model.Entity.User", "User")
                        .WithMany("Company")
                        .HasForeignKey("CreatedByUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
