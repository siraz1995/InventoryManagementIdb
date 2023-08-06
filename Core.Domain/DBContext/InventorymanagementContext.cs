using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Domain.DBContext
{
    public partial class InventorymanagementContext : DbContext
    {
        public InventorymanagementContext()
        {
        }

        public InventorymanagementContext(DbContextOptions<InventorymanagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; } = null!;
        public virtual DbSet<PurchaseHeader> PurchaseHeaders { get; set; } = null!;
        public virtual DbSet<PurchaseOrederReturnHeader> PurchaseOrederReturnHeaders { get; set; } = null!;
        public virtual DbSet<PurchaseOrederReturnInfo> PurchaseOrederReturnInfos { get; set; } = null!;
        public virtual DbSet<SalesDetail> SalesDetails { get; set; } = null!;
        public virtual DbSet<SalesHeader> SalesHeaders { get; set; } = null!;
        public virtual DbSet<SalesReturnDetail> SalesReturnDetails { get; set; } = null!;
        public virtual DbSet<SalesReturnHeader> SalesReturnHeaders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Inventorymanagement;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceNo, e.ProductCode })
                    .HasName("PK__Purchase__2562520226D05215");

                entity.ToTable("PurchaseDetail");

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ProductCode).HasMaxLength(10);

                entity.Property(e => e.Discription).HasMaxLength(200);

                entity.Property(e => e.SalesPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UnitTypeCode).HasMaxLength(10);
            });

            modelBuilder.Entity<PurchaseHeader>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo)
                    .HasName("PK__Purchase__D796B22659339F0A");

                entity.ToTable("PurchaseHeader");

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.NetTotal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Remarks).HasMaxLength(20);

                entity.Property(e => e.ShopCode).HasMaxLength(20);

                entity.Property(e => e.Tax).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VendorCode).HasMaxLength(100);
            });

            modelBuilder.Entity<PurchaseOrederReturnHeader>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo)
                    .HasName("PK__Purchase__D796B2268E3252E7");

                entity.ToTable("PurchaseOrederReturnHeader");

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.NetTotal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShopCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tax).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VendorCode).HasMaxLength(10);
            });

            modelBuilder.Entity<PurchaseOrederReturnInfo>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceNo, e.ProductCode })
                    .HasName("PK__Purchase__256252021A57D65A");

                entity.ToTable("PurchaseOrederReturnInfo");

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ProductCode).HasMaxLength(10);

                entity.Property(e => e.Discription).HasMaxLength(200);

                entity.Property(e => e.SalesPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UnitTypeCode).HasMaxLength(10);
            });

            modelBuilder.Entity<SalesDetail>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceNo, e.ProductCode })
                    .HasName("PK__SalesDet__25625202444DF743");

                entity.ToTable("SalesDetail");

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ProductCode).HasMaxLength(10);

                entity.Property(e => e.Discription).HasMaxLength(200);

                entity.Property(e => e.SalesPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UnitTypeCode).HasMaxLength(10);
            });

            modelBuilder.Entity<SalesHeader>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo)
                    .HasName("PK__SalesHea__D796B226D34B9DDE");

                entity.ToTable("SalesHeader");

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CustomerName).HasMaxLength(70);

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.NetTotal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ShopCode).HasMaxLength(20);

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Vat).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<SalesReturnDetail>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceNo, e.ProductCode })
                    .HasName("PK__SalesRet__256252025D33D85D");

                entity.ToTable("SalesReturnDetail");

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ProductCode).HasMaxLength(10);

                entity.Property(e => e.Discription).HasMaxLength(200);

                entity.Property(e => e.SalesPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UnitTypeCode).HasMaxLength(10);
            });

            modelBuilder.Entity<SalesReturnHeader>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo)
                    .HasName("PK__SalesRet__D796B22604EA73AA");

                entity.ToTable("SalesReturnHeader");

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CustomerName).HasMaxLength(100);

                entity.Property(e => e.InvoiceDate).HasColumnType("smalldatetime");

                entity.Property(e => e.NetTotal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ShopCode).HasMaxLength(20);

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Vat).HasColumnType("numeric(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
