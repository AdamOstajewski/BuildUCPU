using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BuildUCPU;

public partial class Builducpu1Context : DbContext
{
    public Builducpu1Context()
    {
    }

    public Builducpu1Context(DbContextOptions<Builducpu1Context> options)
        : base(options)
    {
    }
    public void Obudowy(Obudowy obudowy)
    {
        Obudowies.Add(obudowy);
        SaveChanges();
    }
    public virtual DbSet<Chlodzenie> Chlodzenies { get; set; }

    public virtual DbSet<DyskiTwarde> DyskiTwardes { get; set; }

    public virtual DbSet<GotoweZestawy> GotoweZestawies { get; set; }

    public virtual DbSet<KartyGraficzne> KartyGraficznes { get; set; }

    public virtual DbSet<Kompatybilnosc> Kompatybilnoscs { get; set; }

    public virtual DbSet<Obudowy> Obudowies { get; set; }

    public virtual DbSet<PamieciRam> PamieciRams { get; set; }

    public virtual DbSet<PlytyGlowne> PlytyGlownes { get; set; }

    public virtual DbSet<Procesory> Procesories { get; set; }

    public virtual DbSet<Zasilacze> Zasilaczes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=builducpu1;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_polish_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Chlodzenie>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("PRIMARY");

            entity
                .ToTable("chlodzenie")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.KompatybilnoscId, "kompatybilnosc_id");

            entity.Property(e => e.Nr).HasColumnType("int(11)");
            entity.Property(e => e.Cena).HasPrecision(10, 2);
            entity.Property(e => e.DodatkoweFunkcje)
                .HasMaxLength(255)
                .HasColumnName("Dodatkowe_funkcje");
            entity.Property(e => e.Dostepnosc).HasColumnType("enum('Tak','Nie')");
            entity.Property(e => e.Gwarancja).HasMaxLength(50);
            entity.Property(e => e.Kompatybilnosc).HasMaxLength(255);
            entity.Property(e => e.KompatybilnoscId)
                .HasColumnType("int(11)")
                .HasColumnName("kompatybilnosc_id");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Producent).HasMaxLength(50);
            entity.Property(e => e.Wydajnosc).HasMaxLength(100);

            entity.HasOne(d => d.KompatybilnoscNavigation).WithMany(p => p.Chlodzenies)
                .HasForeignKey(d => d.KompatybilnoscId)
                .HasConstraintName("chlodzenie_ibfk_1");
        });

        modelBuilder.Entity<DyskiTwarde>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("PRIMARY");

            entity
                .ToTable("dyski_twarde")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.KompatybilnoscId, "kompatybilnosc_id");

            entity.Property(e => e.Nr).HasColumnType("int(11)");
            entity.Property(e => e.Cena).HasPrecision(10, 2);
            entity.Property(e => e.DodatkoweFunkcje)
                .HasMaxLength(255)
                .HasColumnName("Dodatkowe_funkcje");
            entity.Property(e => e.Dostepnosc).HasColumnType("enum('Tak','Nie')");
            entity.Property(e => e.Gwarancja).HasMaxLength(50);
            entity.Property(e => e.Kompatybilnosc).HasMaxLength(255);
            entity.Property(e => e.KompatybilnoscId)
                .HasColumnType("int(11)")
                .HasColumnName("kompatybilnosc_id");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Producent).HasMaxLength(50);
            entity.Property(e => e.Wydajnosc).HasMaxLength(100);

            entity.HasOne(d => d.KompatybilnoscNavigation).WithMany(p => p.DyskiTwardes)
                .HasForeignKey(d => d.KompatybilnoscId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dyski_twarde_ibfk_1");
        });

        modelBuilder.Entity<GotoweZestawy>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("PRIMARY");

            entity
                .ToTable("gotowe_zestawy")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.ChlodzenieId, "chlodzenie_id");

            entity.HasIndex(e => e.DyskiTwardeId, "dyski_twarde_id");

            entity.HasIndex(e => e.KartyGraficzneId, "karty_graficzne_id");

            entity.HasIndex(e => e.ObudowyId, "obudowy_id");

            entity.HasIndex(e => e.PamieciRamId, "pamieci_ram_id");

            entity.HasIndex(e => e.PlytyGlowneId, "plyty_glowne_id");

            entity.HasIndex(e => e.ProcesoryId, "procesory_id");

            entity.HasIndex(e => e.ZasilaczeId, "zasilacze_id");

            entity.Property(e => e.Nr).HasColumnType("int(11)");
            entity.Property(e => e.ChlodzenieId)
                .HasColumnType("int(11)")
                .HasColumnName("chlodzenie_id");
            entity.Property(e => e.DyskiTwardeId)
                .HasColumnType("int(11)")
                .HasColumnName("dyski_twarde_id");
            entity.Property(e => e.KartyGraficzneId)
                .HasColumnType("int(11)")
                .HasColumnName("karty_graficzne_id");
            entity.Property(e => e.ObudowyId)
                .HasColumnType("int(11)")
                .HasColumnName("obudowy_id");
            entity.Property(e => e.PamieciRamId)
                .HasColumnType("int(11)")
                .HasColumnName("pamieci_ram_id");
            entity.Property(e => e.PlytyGlowneId)
                .HasColumnType("int(11)")
                .HasColumnName("plyty_glowne_id");
            entity.Property(e => e.ProcesoryId)
                .HasColumnType("int(11)")
                .HasColumnName("procesory_id");
            entity.Property(e => e.Sekcja).HasMaxLength(50);
            entity.Property(e => e.ZasilaczeId)
                .HasColumnType("int(11)")
                .HasColumnName("zasilacze_id");

            entity.HasOne(d => d.Chlodzenie).WithMany(p => p.GotoweZestawies)
                .HasForeignKey(d => d.ChlodzenieId)
                .HasConstraintName("gotowe_zestawy_ibfk_1");

            entity.HasOne(d => d.DyskiTwarde).WithMany(p => p.GotoweZestawies)
                .HasForeignKey(d => d.DyskiTwardeId)
                .HasConstraintName("gotowe_zestawy_ibfk_2");

            entity.HasOne(d => d.KartyGraficzne).WithMany(p => p.GotoweZestawies)
                .HasForeignKey(d => d.KartyGraficzneId)
                .HasConstraintName("gotowe_zestawy_ibfk_3");

            entity.HasOne(d => d.Obudowy).WithMany(p => p.GotoweZestawies)
                .HasForeignKey(d => d.ObudowyId)
                .HasConstraintName("gotowe_zestawy_ibfk_4");

            entity.HasOne(d => d.PamieciRam).WithMany(p => p.GotoweZestawies)
                .HasForeignKey(d => d.PamieciRamId)
                .HasConstraintName("gotowe_zestawy_ibfk_5");

            entity.HasOne(d => d.PlytyGlowne).WithMany(p => p.GotoweZestawies)
                .HasForeignKey(d => d.PlytyGlowneId)
                .HasConstraintName("gotowe_zestawy_ibfk_6");

            entity.HasOne(d => d.Procesory).WithMany(p => p.GotoweZestawies)
                .HasForeignKey(d => d.ProcesoryId)
                .HasConstraintName("gotowe_zestawy_ibfk_7");

            entity.HasOne(d => d.Zasilacze).WithMany(p => p.GotoweZestawies)
                .HasForeignKey(d => d.ZasilaczeId)
                .HasConstraintName("gotowe_zestawy_ibfk_8");
        });

        modelBuilder.Entity<KartyGraficzne>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("PRIMARY");

            entity
                .ToTable("karty_graficzne")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.KompatybilnoscId, "kompatybilnosc_id");

            entity.Property(e => e.Nr).HasColumnType("int(11)");
            entity.Property(e => e.Cena).HasPrecision(10, 2);
            entity.Property(e => e.DodatkoweFunkcje)
                .HasMaxLength(255)
                .HasColumnName("Dodatkowe_funkcje");
            entity.Property(e => e.Dostepnosc).HasColumnType("enum('Tak','Nie')");
            entity.Property(e => e.Gwarancja).HasMaxLength(50);
            entity.Property(e => e.Kompatybilnosc).HasMaxLength(50);
            entity.Property(e => e.KompatybilnoscId)
                .HasColumnType("int(11)")
                .HasColumnName("kompatybilnosc_id");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Producent).HasMaxLength(50);
            entity.Property(e => e.Wydajnosc).HasMaxLength(100);

            entity.HasOne(d => d.KompatybilnoscNavigation).WithMany(p => p.KartyGraficznes)
                .HasForeignKey(d => d.KompatybilnoscId)
                .HasConstraintName("karty_graficzne_ibfk_1");
        });

        modelBuilder.Entity<Kompatybilnosc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("kompatybilnosc")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(15)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Obudowy>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("PRIMARY");

            entity
                .ToTable("obudowy")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.KompatybilnoscId, "kompatybilnosc_id");

            entity.Property(e => e.Nr).HasColumnType("int(11)");
            entity.Property(e => e.Cena).HasPrecision(10, 2);
            entity.Property(e => e.DodatkoweFunkcje)
                .HasMaxLength(255)
                .HasColumnName("Dodatkowe_funkcje");
            entity.Property(e => e.Dostepnosc).HasColumnType("enum('Tak','Nie')");
            entity.Property(e => e.Gwarancja).HasMaxLength(50);
            entity.Property(e => e.Kompatybilnosc).HasMaxLength(100);
            entity.Property(e => e.KompatybilnoscId)
                .HasColumnType("int(11)")
                .HasColumnName("kompatybilnosc_id");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Producent).HasMaxLength(50);
            entity.Property(e => e.Wydajnosc).HasMaxLength(50);

            entity.HasOne(d => d.KompatybilnoscNavigation).WithMany(p => p.Obudowies)
                .HasForeignKey(d => d.KompatybilnoscId)
                .HasConstraintName("obudowy_ibfk_1");
        });

        modelBuilder.Entity<PamieciRam>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("PRIMARY");

            entity
                .ToTable("pamieci_ram")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.KompatybilnoscId, "kompatybilnosc_id");

            entity.Property(e => e.Nr).HasColumnType("int(11)");
            entity.Property(e => e.Cena).HasPrecision(10, 2);
            entity.Property(e => e.DodatkoweFunkcje)
                .HasMaxLength(255)
                .HasColumnName("Dodatkowe_funkcje");
            entity.Property(e => e.Dostepnosc).HasColumnType("enum('Tak','Nie')");
            entity.Property(e => e.Gwarancja).HasMaxLength(50);
            entity.Property(e => e.Kompatybilnosc).HasMaxLength(50);
            entity.Property(e => e.KompatybilnoscId)
                .HasColumnType("int(11)")
                .HasColumnName("kompatybilnosc_id");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Producent).HasMaxLength(50);
            entity.Property(e => e.Wydajnosc).HasMaxLength(100);

            entity.HasOne(d => d.KompatybilnoscNavigation).WithMany(p => p.PamieciRams)
                .HasForeignKey(d => d.KompatybilnoscId)
                .HasConstraintName("pamieci_ram_ibfk_1");
        });

        modelBuilder.Entity<PlytyGlowne>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("PRIMARY");

            entity
                .ToTable("plyty_glowne")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.KompatybilnoscId, "kompatybilnosc_id");

            entity.Property(e => e.Nr).HasColumnType("int(11)");
            entity.Property(e => e.Cena).HasPrecision(10, 2);
            entity.Property(e => e.DodatkoweFunkcje)
                .HasMaxLength(255)
                .HasColumnName("Dodatkowe_funkcje");
            entity.Property(e => e.Dostepnosc).HasColumnType("enum('Tak','Nie')");
            entity.Property(e => e.Gwarancja).HasMaxLength(50);
            entity.Property(e => e.Kompatybilnosc).HasMaxLength(100);
            entity.Property(e => e.KompatybilnoscId)
                .HasColumnType("int(11)")
                .HasColumnName("kompatybilnosc_id");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Producent).HasMaxLength(50);
            entity.Property(e => e.Rozmiar).HasMaxLength(50);

            entity.HasOne(d => d.KompatybilnoscNavigation).WithMany(p => p.PlytyGlownes)
                .HasForeignKey(d => d.KompatybilnoscId)
                .HasConstraintName("plyty_glowne_ibfk_1");
        });

        modelBuilder.Entity<Procesory>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("PRIMARY");

            entity
                .ToTable("procesory")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.KompatybilnoscId, "kompatybilnosc_id");

            entity.Property(e => e.Nr).HasColumnType("int(11)");
            entity.Property(e => e.Cena).HasPrecision(10, 2);
            entity.Property(e => e.DodatkoweFunkcje)
                .HasMaxLength(255)
                .HasColumnName("Dodatkowe_funkcje");
            entity.Property(e => e.Dostepnosc).HasColumnType("enum('Tak','Nie')");
            entity.Property(e => e.Gwarancja).HasMaxLength(50);
            entity.Property(e => e.Kompatybilnosc).HasMaxLength(50);
            entity.Property(e => e.KompatybilnoscId)
                .HasColumnType("int(11)")
                .HasColumnName("kompatybilnosc_id");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Producent).HasMaxLength(50);
            entity.Property(e => e.Wydajnosc).HasMaxLength(100);

            entity.HasOne(d => d.KompatybilnoscNavigation).WithMany(p => p.Procesories)
                .HasForeignKey(d => d.KompatybilnoscId)
                .HasConstraintName("procesory_ibfk_1");
        });

        modelBuilder.Entity<Zasilacze>(entity =>
        {
            entity.HasKey(e => e.Nr).HasName("PRIMARY");

            entity
                .ToTable("zasilacze")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.KompatybilnoscId, "kompatybilnosc_id");

            entity.Property(e => e.Nr).HasColumnType("int(11)");
            entity.Property(e => e.Cena).HasPrecision(10, 2);
            entity.Property(e => e.DodatkoweFunkcje)
                .HasMaxLength(255)
                .HasColumnName("Dodatkowe_funkcje");
            entity.Property(e => e.Dostepnosc).HasColumnType("enum('Tak','Nie')");
            entity.Property(e => e.Gwarancja).HasMaxLength(50);
            entity.Property(e => e.Kompatybilnosc).HasMaxLength(50);
            entity.Property(e => e.KompatybilnoscId)
                .HasColumnType("int(11)")
                .HasColumnName("kompatybilnosc_id");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Producent).HasMaxLength(50);
            entity.Property(e => e.Wydajnosc).HasMaxLength(100);

            entity.HasOne(d => d.KompatybilnoscNavigation).WithMany(p => p.Zasilaczes)
                .HasForeignKey(d => d.KompatybilnoscId)
                .HasConstraintName("zasilacze_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
