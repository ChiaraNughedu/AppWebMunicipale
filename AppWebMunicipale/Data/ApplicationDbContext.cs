using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppWebMunicipale.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anagrafica> Anagraficas { get; set; }

    public virtual DbSet<TipoViolazione> TipoViolaziones { get; set; }

    public virtual DbSet<Verbale> Verbales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-F9379OP3\\SQLEXPRESS;Database=PROGETTO2802;User ID=sa;Password=sa;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anagrafica>(entity =>
        {
            entity.HasKey(e => e.IdAnagrafica).HasName("PK__Anagrafi__FFDE839192B66100");

            entity.Property(e => e.CodFisc).IsFixedLength();
        });

        modelBuilder.Entity<TipoViolazione>(entity =>
        {
            entity.HasKey(e => e.IdViolazione).HasName("PK__TipoViol__75080923DF9CA88D");
        });

        modelBuilder.Entity<Verbale>(entity =>
        {
            entity.HasKey(e => e.IdVerbale).HasName("PK__Verbale__A0FAF4531C8797B1");

            entity.HasOne(d => d.IdAnagraficaNavigation).WithMany(p => p.Verbales).HasConstraintName("FK__Verbale__idAnagr__5DCAEF64");

            entity.HasOne(d => d.IdViolazioneNavigation).WithMany(p => p.Verbales).HasConstraintName("FK__Verbale__idViola__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
