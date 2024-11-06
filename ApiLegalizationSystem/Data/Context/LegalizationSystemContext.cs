using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiLegalizationSystem.Data.Models;

public partial class LegalizationSystemContext : DbContext
{
    public LegalizationSystemContext()
    {
    }

    public LegalizationSystemContext(DbContextOptions<LegalizationSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C53E2B236");

            entity.HasIndex(e => e.IdentityDocument, "UQ__Users__9ACBD5A0F9AE65EC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105340F035F75").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50)
                              .HasConversion<string>(); // Configura la propiedad Role como string en la base de datos
            ;
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
