using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Entities;

public class Review
{
    public int Id { get; set; }
    public string Headline { get; set; }
    public int Rating { get; set; }
    public string ReviewerName { get; set; }
    public virtual Movie? Movie { get; set; }
    public int MovieId { get; set; }

}

public class ReviewValidator : AbstractValidator<Review>
{
    public ReviewValidator()
    {
       
    }
}

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public int ReleaseYear { get; set; }
    public int BoxOfficeSumInMillions { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}

public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(m => m.Title)
            .Must(ValidateTitle)
            .WithMessage("Title must be greater than 5 chars + have B");
    }
    private static bool ValidateTitle(string title)
    {
        if (title.Length > 5 && title.Contains("b"))
        {
            return true;
        }
        return false;
    }
}
