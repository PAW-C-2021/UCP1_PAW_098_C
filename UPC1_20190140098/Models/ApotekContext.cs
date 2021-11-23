using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UPC1_20190140098.Models
{
    public partial class ApotekContext : DbContext
    {
        public ApotekContext()
        {
        }

        public ApotekContext(DbContextOptions<ApotekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Konsumen> Konsumen { get; set; }
        public virtual DbSet<PetugasApotek> PetugasApotek { get; set; }
        public virtual DbSet<TabelObat> TabelObat { get; set; }
        public virtual DbSet<TabelTransaksi> TabelTransaksi { get; set; }
        public virtual DbSet<TableNota> TableNota { get; set; }
        public virtual DbSet<Transaksii> Transaksii { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-FFUAFKEG;Database=Apotek;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Konsumen>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.ToTable("konsumen");

                entity.Property(e => e.IdPembeli)
                    .HasColumnName("ID_pembeli")
                    .ValueGeneratedNever();

                entity.Property(e => e.PasswordPembei)
                    .HasColumnName("Password_pembei")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UsernamePembeli)
                    .HasColumnName("username_pembeli")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PetugasApotek>(entity =>
            {
                entity.HasKey(e => e.IdApoteker);

                entity.ToTable("Petugas_apotek");

                entity.Property(e => e.IdApoteker)
                    .HasColumnName("ID_apoteker")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdObat).HasColumnName("ID_obat");

                entity.Property(e => e.IdPembeli).HasColumnName("ID_pembeli");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdObatNavigation)
                    .WithMany(p => p.PetugasApotek)
                    .HasForeignKey(d => d.IdObat)
                    .HasConstraintName("FK_Petugas_apotek_Tabel_obat");

                entity.HasOne(d => d.IdPembeliNavigation)
                    .WithMany(p => p.PetugasApotek)
                    .HasForeignKey(d => d.IdPembeli)
                    .HasConstraintName("FK_Petugas_apotek_konsumen");
            });

            modelBuilder.Entity<TabelObat>(entity =>
            {
                entity.HasKey(e => e.IdObat);

                entity.ToTable("Tabel_obat");

                entity.Property(e => e.IdObat)
                    .HasColumnName("ID_obat")
                    .ValueGeneratedNever();

                entity.Property(e => e.JenisObat)
                    .HasColumnName("Jenis_obat")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NamaObat)
                    .HasColumnName("Nama_obat")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<TabelTransaksi>(entity =>
            {
                entity.HasKey(e => e.IdNota);

                entity.ToTable("Tabel_transaksi");

                entity.Property(e => e.IdNota)
                    .HasColumnName("ID_Nota")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTransaksi).HasColumnName("ID_transaksi");

                entity.Property(e => e.TotalHarga).HasColumnName("total_harga");
            });

            modelBuilder.Entity<TableNota>(entity =>
            {
                entity.HasKey(e => e.IdNota);

                entity.ToTable("Table_Nota");

                entity.Property(e => e.IdNota)
                    .HasColumnName("ID_Nota")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTransaksi).HasColumnName("ID_transaksi");

                entity.Property(e => e.TotalHarga).HasColumnName("total_harga");

                entity.HasOne(d => d.IdNotaNavigation)
                    .WithOne(p => p.TableNota)
                    .HasForeignKey<TableNota>(d => d.IdNota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_Nota_Tabel_transaksi");

                entity.HasOne(d => d.IdTransaksiNavigation)
                    .WithMany(p => p.TableNota)
                    .HasForeignKey(d => d.IdTransaksi)
                    .HasConstraintName("FK_Table_Nota_transaksii");
            });

            modelBuilder.Entity<Transaksii>(entity =>
            {
                entity.HasKey(e => e.IdTransaksii);

                entity.ToTable("transaksii");

                entity.Property(e => e.IdTransaksii)
                    .HasColumnName("ID_transaksii")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdObat).HasColumnName("ID_obat");

                entity.Property(e => e.IdPembeli).HasColumnName("ID_pembeli");

                entity.Property(e => e.TglTransaksi)
                    .HasColumnName("tgl_transaksi")
                    .HasColumnType("date");

                entity.Property(e => e.TotalHarga).HasColumnName("total_harga");

                entity.HasOne(d => d.IdPembeliNavigation)
                    .WithMany(p => p.Transaksii)
                    .HasForeignKey(d => d.IdPembeli)
                    .HasConstraintName("FK_transaksii_konsumen");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
