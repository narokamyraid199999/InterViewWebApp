﻿// <auto-generated />
using System;
using InterViewWebApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InterViewWebApp.Migrations
{
    [DbContext(typeof(shopDbContext))]
    partial class shopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InterViewWebApp.Model.InvoiceDetails", b =>
                {
                    b.Property<int>("lineNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("lineNo"));

                    b.Property<int?>("UnitNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("expiryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("lineNo");

                    b.HasIndex("UnitNo");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("InterViewWebApp.Model.Unit", b =>
                {
                    b.Property<int>("unitNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("unitNo"));

                    b.Property<string>("unitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("unitNo");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("InterViewWebApp.Model.InvoiceDetails", b =>
                {
                    b.HasOne("InterViewWebApp.Model.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitNo");

                    b.Navigation("Unit");
                });
#pragma warning restore 612, 618
        }
    }
}