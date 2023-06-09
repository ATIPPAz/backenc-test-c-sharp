using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using gps_test.Models;

namespace gps_test.Context;

public partial class gpsContext : DbContext
{
    public gpsContext(DbContextOptions<gpsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<location> locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<location>(entity =>
        {
            entity.HasKey(e => e.locationId).HasName("PRIMARY");

            entity.ToTable("location");

            entity.Property(e => e.locationLat).HasPrecision(20, 16);
            entity.Property(e => e.locationLng).HasPrecision(20, 16);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
