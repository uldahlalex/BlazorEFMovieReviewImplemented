using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class ImplementedDbContext : Microsoft.EntityFrameworkCore.DbContext
{

    public ImplementedDbContext(DbContextOptions<ImplementedDbContext> options, ServiceLifetime serviceLifetime) : base(options)
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
        

        modelBuilder.Entity<Movie>()
            .Ignore(m => m.Reviews);

        modelBuilder.Entity<Movie>()
            .HasData(new Movie()
            {
                Id = 1, Summary = "seeded", Title = "seeded", ReleaseYear = 2022,
                BoxOfficeSumInMillions = 42
            });

    }

    public DbSet<Movie> MovieTable { get; set; }
    public DbSet<Review> ReviewTable { get; set; }
}