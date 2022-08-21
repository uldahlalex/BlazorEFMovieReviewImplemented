namespace Entities;

public interface IRepository
{
    IEnumerable<Review> GetReviews();

    IEnumerable<Movie> GetMovies();
    Movie DeleteMovie(int movieId);
    Review DeleteReview(int reviewId); 
    Movie AddMovie(Movie movie);
    Review AddReview(Review review);
}
