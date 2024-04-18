using System;
using System.Collections.Generic;
using Alv.Parkering.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Alv.Parkering.Infrastructure.Context;

public partial class ParkeringContext : DbContext
{
    public ParkeringContext()
    {
    }

    public ParkeringContext(DbContextOptions<ParkeringContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Detailjer> Detailjers { get; set; }

    public virtual DbSet<Parkeringer> Parkeringers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=../../data-creator/parkering.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Detailjer>(entity =>
        {
            entity.ToTable("detailjer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Adresse).HasColumnName("adresse");
            entity.Property(e => e.Aktiveringstidspunkt).HasColumnName("aktiveringstidspunkt");
            entity.Property(e => e.AntallAvgiftsbelagtePlasser).HasColumnName("antallAvgiftsbelagtePlasser");
            entity.Property(e => e.AntallAvgiftsfriePlasser)
                .HasColumnType("INTEGER")
                .HasColumnName("antallAvgiftsfriePlasser");
            entity.Property(e => e.AntallForflytningshemmede).HasColumnName("antallForflytningshemmede");
            entity.Property(e => e.AntallLadeplasser).HasColumnName("antallLadeplasser");
            entity.Property(e => e.Innfartsparkering)
                .HasColumnType("tex")
                .HasColumnName("innfartsparkering");
            entity.Property(e => e.Navn).HasColumnName("navn");
            entity.Property(e => e.OpplastetVurderingId).HasColumnName("opplastetVurderingId");
            entity.Property(e => e.Postnummer).HasColumnName("postnummer");
            entity.Property(e => e.Poststed).HasColumnName("poststed");
            entity.Property(e => e.Referanse).HasColumnName("referanse");
            entity.Property(e => e.SistEndret).HasColumnName("sistEndret");
            entity.Property(e => e.SkiltplanId).HasColumnName("skiltplanId");
            entity.Property(e => e.Sluttidspunkt).HasColumnName("sluttidspunkt");
            entity.Property(e => e.TypeParkeringsomrade).HasColumnName("typeParkeringsomrade");
            entity.Property(e => e.Versjonsnummer).HasColumnName("versjonsnummer");
            entity.Property(e => e.VurderingForflytningshemmede).HasColumnName("vurderingForflytningshemmede");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Detailjer)
                .HasForeignKey<Detailjer>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Parkeringer>(entity =>
        {
            entity.ToTable("parkeringer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Adresse).HasColumnName("adresse");
            entity.Property(e => e.Aktiveringstidspunkt)
                .HasColumnType("tex")
                .HasColumnName("aktiveringstidspunkt");
            entity.Property(e => e.Breddegrad)
                .HasColumnType("INTEGER")
                .HasColumnName("breddegrad");
            entity.Property(e => e.Deaktivert).HasColumnName("deaktivert");
            entity.Property(e => e.Lengdegrad)
                .HasColumnType("INTEGER")
                .HasColumnName("lengdegrad");
            entity.Property(e => e.Navn).HasColumnName("navn");
            entity.Property(e => e.ParkeringstilbyderNavn).HasColumnName("parkeringstilbyderNavn");
            entity.Property(e => e.Postnummer).HasColumnName("postnummer");
            entity.Property(e => e.Poststed).HasColumnName("poststed");
            entity.Property(e => e.Versjonsnummer).HasColumnName("versjonsnummer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
