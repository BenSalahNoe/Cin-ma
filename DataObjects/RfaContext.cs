using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WinForms_EntityFramework.DataObjects;

public partial class RfaContext : DbContext
{
    public RfaContext()
    {
    }

    public RfaContext(DbContextOptions<RfaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Filmactor> Filmactors { get; set; }

    public virtual DbSet<Filmdirector> Filmdirectors { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=rfa;password=rfa;database=rfa", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("actor")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Nom).HasMaxLength(50);
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("director")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Nom).HasMaxLength(50);
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("film")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Duree).HasColumnType("time");
            entity.Property(e => e.Titre).HasMaxLength(50);
        });

        modelBuilder.Entity<Filmactor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("filmactor")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdActor, "IdActor");

            entity.HasIndex(e => e.IdFilm, "IdFilm");

            entity.HasOne(d => d.IdActorNavigation).WithMany(p => p.Filmactors)
                .HasForeignKey(d => d.IdActor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("filmactor_ibfk_2");

            entity.HasOne(d => d.IdFilmNavigation).WithMany(p => p.Filmactors)
                .HasForeignKey(d => d.IdFilm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("filmactor_ibfk_1");
        });

        modelBuilder.Entity<Filmdirector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("filmdirector")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.IdDirector, "IdDirector");

            entity.HasIndex(e => e.IdFilm, "IdFilm");

            entity.HasOne(d => d.IdDirectorNavigation).WithMany(p => p.Filmdirectors)
                .HasForeignKey(d => d.IdDirector)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("filmdirector_ibfk_2");

            entity.HasOne(d => d.IdFilmNavigation).WithMany(p => p.Filmdirectors)
                .HasForeignKey(d => d.IdFilm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("filmdirector_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
