using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_110.Models
{
    public partial class OnlineMartContext : DbContext
    {
        public OnlineMartContext()
        {
        }

        public OnlineMartContext(DbContextOptions<OnlineMartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Costumer> Costumers { get; set; }
        public virtual DbSet<Transaksii> Transaksiis { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_admin");

                entity.Property(e => e.NamaAdmin)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nama_admin");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.ToTable("Barang");

                entity.Property(e => e.IdBarang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_barang");

                entity.Property(e => e.Harga).HasColumnName("harga");

                entity.Property(e => e.Kuantitas).HasColumnName("kuantitas");

                entity.Property(e => e.NamaBarang)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("nama_barang");
            });

            modelBuilder.Entity<Costumer>(entity =>
            {
                entity.HasKey(e => e.IdCostumer);

                entity.ToTable("Costumer");

                entity.Property(e => e.IdCostumer)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_costumer");

                entity.Property(e => e.Alamat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alamat");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.NamaCostumer)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nama_costumer");

                entity.Property(e => e.NomorTelepon).HasColumnName("nomor_telepon");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Transaksii>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksii");

                entity.Property(e => e.IdTransaksi)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_transaksi");

                entity.Property(e => e.Bayar).HasColumnName("bayar");

                entity.Property(e => e.IdAdmin)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_admin");

                entity.Property(e => e.IdBarang)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_barang");

                entity.Property(e => e.IdCostumer)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_costumer");

                entity.Property(e => e.Kembalian).HasColumnName("kembalian");

                entity.Property(e => e.Tanggal).HasColumnName("tanggal");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Transaksiis)
                    .HasForeignKey(d => d.IdAdmin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksii_Admin");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany(p => p.Transaksiis)
                    .HasForeignKey(d => d.IdBarang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksii_Barang");

                entity.HasOne(d => d.IdCostumerNavigation)
                    .WithMany(p => p.Transaksiis)
                    .HasForeignKey(d => d.IdCostumer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksii_Costumer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
