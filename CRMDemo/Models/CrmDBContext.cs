using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRMDemo.Models
{
    public partial class CrmDBContext : DbContext
    {
        public CrmDBContext()
        {
        }

        public CrmDBContext(DbContextOptions<CrmDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<CusRank> CusRanks { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceInfo> InvoiceInfos { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1I18VEE\\sqlexpress;Database=CrmDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Pass).HasMaxLength(15);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Account_Branch");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Account_Position");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchAddress).HasColumnType("ntext");

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            });

            modelBuilder.Entity<CusRank>(entity =>
            {
                entity.ToTable("CusRank");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Condition).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RankName).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CusAddress).HasColumnType("ntext");

                entity.Property(e => e.CusName).HasMaxLength(50);

                entity.Property(e => e.CusRankId).HasColumnName("CusRankID");

                entity.Property(e => e.Expense).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.HasOne(d => d.CusRank)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CusRankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Customer_CusRank");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CusId).HasColumnName("CusID");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.VoucherId).HasColumnName("VoucherID");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Invoice_Branch");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Invoice_Customer");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Invoice_Account");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Invoice_Voucher");
            });

            modelBuilder.Entity<InvoiceInfo>(entity =>
            {
                entity.ToTable("InvoiceInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceInfos)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InvoiceInfo_Invoice");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceInfos)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InvoiceInfo_Product");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PositionName).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.Unit).HasMaxLength(20);
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Condition).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Exd)
                    .HasColumnType("date")
                    .HasColumnName("EXD")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VoucherName).HasMaxLength(100);

                entity.Property(e => e.VoucherValue).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
