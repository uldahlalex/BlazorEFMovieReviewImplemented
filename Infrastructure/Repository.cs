﻿using System.Threading.Channels;
using Entities;
using Microsoft.EntityFrameworkCore;
using ValidationResult = FluentValidation.Results.ValidationResult;


namespace Infrastructure;

public class Repository :  IRepository
{

    private Movie mockMovieObject;
    private Review mockReviewObject;
    private DbContextOptions<RepositoryDbContext> _opts;

    public Repository()
    {
        mockMovieObject =new Movie()
        {
            Id = 1, Summary = "Bob writes a program ...", Title = "a", ReleaseYear = 2022,
            BoxOfficeSumInMillions = 42, Reviews = new List<Review>() {new Review()}
        };
        mockReviewObject = new Review()
        {
            Id = 1, Headline = "Super great movie", Rating = 5,
            ReviewerName = "Smølf", MovieId = 1, Movie = mockMovieObject
        };

        var result = new MovieValidator()
            .Validate(mockMovieObject)
            .Errors.ToList();
        result.ForEach(e =>
        {
            Console.WriteLine(e.ErrorMessage);
        });

        _opts = new DbContextOptionsBuilder<RepositoryDbContext>()
            .UseSqlite("Data source=..//GUI/db.db").Options;
    }

    public List<Review> GetReviews()
    {
        return new List<Review>() { mockReviewObject };
    }

    public List<Movie> GetMovies()
    {
        return new List<Movie>() { mockMovieObject };
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
        return movie;
    }

    public Review AddReview(Review review)
    {
        review.Movie = new Movie();
        return review;
    }
}