﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Models;

public partial class MovieAppDbContext : DbContext
{
    public MovieAppDbContext()
    {
    }

    public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MovieAppDB;Trusted_Connection=True;TrustServerCertificate=true;");
                         

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PK__Actor__57B3EA2BE2C7B78B");

            entity.ToTable("Actor");

            entity.Property(e => e.ActorId).HasColumnName("ActorID");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genre__0385055EEA2D7526");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movie__4BD2943AB4DC7A8A");

            entity.ToTable("Movie");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.LeadActorId).HasColumnName("LeadActorID");
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie__GenreID__4316F928");

            entity.HasOne(d => d.LeadActor).WithMany(p => p.Movies)
                .HasForeignKey(d => d.LeadActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie__LeadActor__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
