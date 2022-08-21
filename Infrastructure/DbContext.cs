﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{

    public DbContext(DbContextOptions<DbContext> options, ServiceLifetime serviceLifetime) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .Property(m => m.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Review>()
            .Property(m => m.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Reviews)
            .WithOne(r => r.Movie)
            .HasForeignKey(r => r.MovieId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Review>()
            .Ignore(r => r.Movie);

    }

    public DbSet<Movie> MovieTable { get; set; }
    public DbSet<Review> ReviewTable { get; set; }
}