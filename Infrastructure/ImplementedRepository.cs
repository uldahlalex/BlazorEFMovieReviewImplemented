using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class ImplementedRepository : IRepository
{
    
    private DbContextOptions<ImplementedDbContext> _opts;

    public ImplementedRepository()
    {
        _opts = new DbContextOptionsBuilder<ImplementedDbContext>()
            .UseSqlite("Data source=..//GUI/db.db").Options;
        using (var context = new ImplementedDbContext(_opts, ServiceLifetime.Scoped))
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

        }
    }
    public List<Review> GetReviews()
    {
        using (var context = new ImplementedDbContext(_opts, ServiceLifetime.Scoped))
        {
            return context.ReviewTable.Include(r => r.Movie).ToList();
        }
    }

    public List<Movie> GetMovies()
    {
        using (var context = new ImplementedDbContext(_opts, ServiceLifetime.Scoped))
        {
            return context.MovieTable.ToList();
        }
    }

    public Movie DeleteMovie(int movieId)
    {
        using (var context = new ImplementedDbContext(_opts, ServiceLifetime.Scoped))
        {
            var movie = context.MovieTable.Find(movieId) ?? throw new KeyNotFoundException();
            context.MovieTable.Remove(movie);
            context.SaveChanges();
            return movie;
        }
    }

    public Review DeleteReview(int reviewId)
    {
        using (var context = new ImplementedDbContext(_opts, ServiceLifetime.Scoped))
        {
            var review = context.ReviewTable.Find(reviewId) ?? throw new KeyNotFoundException();
            context.ReviewTable.Remove(review);
            context.SaveChanges();
            return review;
        }
    }

    public Movie AddMovie(Movie movie)
    {
        using (var context = new ImplementedDbContext(_opts, ServiceLifetime.Scoped))
        {
            context.MovieTable.Add(movie);
            context.SaveChanges();
            return movie;
        }
    }

    public Review AddReview(Review review)
    {
        using (var context = new ImplementedDbContext(_opts, ServiceLifetime.Scoped))
        {
            review.Movie = context
                .MovieTable
                .Find(review.MovieId) ?? throw new InvalidOperationException();
            context.ReviewTable.Add(review);
            context.SaveChanges();
            return review;
        }
    }
}