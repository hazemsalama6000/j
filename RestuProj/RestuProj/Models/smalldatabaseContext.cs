using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RestuProj.Models
{
    public partial class smalldatabaseContext : DbContext
    {
        public smalldatabaseContext()
        {
        }

        public smalldatabaseContext(DbContextOptions<smalldatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DefUser> DefUsers { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=smalldatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressLocat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("addressLocat");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telepone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DefUser>(entity =>
            {
                entity.ToTable("Def_user");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Pass)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pass");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Orderdate).HasColumnType("date");

                entity.Property(e => e.PaymentId).HasColumnName("paymentID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__1A14E395");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Orders__paymentI__1B0907CE");
            });

            modelBuilder.Entity<OrdersDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FoodId).HasColumnName("FoodID");

                entity.Property(e => e.OrdersId).HasColumnName("Orders_ID");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK__OrdersDet__FoodI__1BFD2C07");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.OrdersId)
                    .HasConstraintName("FK__OrdersDet__Order__1CF15040");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
