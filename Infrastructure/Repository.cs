using System.Runtime.InteropServices.ComTypes;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class Repository :  IRepository
{
    
    private DbContextOptions<DbContext> _opts;

    public Repository()
    {
        _opts = new DbContextOptionsBuilder<DbContext>()
            .UseSqlite("Data source=../Infrastructure/db.db").Options;
    }

    public IEnumerable<Review> GetReviews()
    {
        return new List<Review>() { };
    }

    public IEnumerable<Movie> GetMovies()
    {
        return new List<Movie>() { };
    }

    public Movie DeleteMovie(int movieId)
    {
        return new Movie();
    }

    public Review DeleteReview(int reviewId)
    {
        return new Review();
    }

    public Movie AddMovie(Movie movie)
    {
        return new Movie();
    }

    public Review AddReview(Review review)
    {
        return new Review();
    }
}