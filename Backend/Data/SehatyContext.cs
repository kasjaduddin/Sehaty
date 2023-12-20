using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sehaty.Models;

namespace Sehaty.Data;

public partial class SehatyContext : DbContext
{
    public SehatyContext(DbContextOptions<SehatyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiaryKesehatan> DiaryKesehatans { get; set; }

    public virtual DbSet<TenagaKesehatan> TenagaKesehatans { get; set; }

    public virtual DbSet<Umum> Umums { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<DiaryKesehatan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("diary_kesehatan");

            entity.Property(e => e.BeratBadan)
                .HasPrecision(4, 1)
                .HasColumnName("Berat_badan");
            entity.Property(e => e.Diastolic).HasPrecision(3);
            entity.Property(e => e.GulaDarah)
                .HasPrecision(3)
                .HasColumnName("Gula_darah");
            entity.Property(e => e.Keterangan).HasMaxLength(30);
            entity.Property(e => e.Kolesterol).HasPrecision(3);
            entity.Property(e => e.NamaObat)
                .HasMaxLength(30)
                .HasColumnName("Nama_obat");
            entity.Property(e => e.Systolic).HasPrecision(3);
            entity.Property(e => e.Tinggi).HasPrecision(4, 1);
            entity.Property(e => e.Waktu).HasColumnType("time");
        });

        modelBuilder.Entity<TenagaKesehatan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tenaga_kesehatan");

            entity.HasIndex(e => e.IdDiary, "fk_diary_tenaga_kesehatan");

            entity.HasIndex(e => e.Email, "user_email").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IdDiary).HasColumnName("Id_diary");
            entity.Property(e => e.JenisKelamin)
                .HasColumnType("enum('Pria','Wanita')")
                .HasColumnName("Jenis_kelamin");
            entity.Property(e => e.Nama).HasMaxLength(25);
            entity.Property(e => e.NoStrF)
                .HasColumnType("mediumint unsigned")
                .HasColumnName("No_str_f");
            entity.Property(e => e.NoStrL).HasColumnName("NO_str_l");
            entity.Property(e => e.Spesialis).HasMaxLength(20);
            entity.Property(e => e.TanggalLahir).HasColumnName("Tanggal_lahir");
            entity.Property(e => e.TempatPraktik)
                .HasMaxLength(30)
                .HasColumnName("Tempat_praktik");

            entity.HasOne(d => d.IdDiaryNavigation).WithMany(p => p.TenagaKesehatans)
                .HasForeignKey(d => d.IdDiary)
                .HasConstraintName("fk_diary_tenaga_kesehatan");
        });

        modelBuilder.Entity<Umum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("umum");

            entity.HasIndex(e => e.IdDiary, "fk_diary_kesehatan");

            entity.HasIndex(e => e.Email, "user_email").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IdDiary).HasColumnName("Id_diary");
            entity.Property(e => e.JenisKelamin)
                .HasColumnType("enum('Pria','Wanita')")
                .HasColumnName("Jenis_kelamin");
            entity.Property(e => e.Nama).HasMaxLength(25);
            entity.Property(e => e.TanggalLahir).HasColumnName("Tanggal_lahir");

            entity.HasOne(d => d.IdDiaryNavigation).WithMany(p => p.Umums)
                .HasForeignKey(d => d.IdDiary)
                .HasConstraintName("fk_diary_kesehatan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
