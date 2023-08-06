﻿// <auto-generated />
using System;
using Infrastructure.DB_Connection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DBConnection))]
    [Migration("20230519173129_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.Procurement.TblSalesHeader", b =>
                {
                    b.Property<string>("InvoiceNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("NetTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceNo");

                    b.ToTable("TblSalesHeaders");
                });

            modelBuilder.Entity("Core.Domain.Procurement.TblSalesProductInfo", b =>
                {
                    b.Property<string>("InvoiceNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Qty")
                        .HasColumnType("int");

                    b.Property<decimal?>("SalesPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceNo");

                    b.ToTable("TblSalesProductInfos");
                });
#pragma warning restore 612, 618
        }
    }
}