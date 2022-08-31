using Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private Repository _repo;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        _repo = new Repository();

    }
    
    [HttpGet]
    [Route("GetAllMovies")]
    public ActionResult GetMovies()
    {
        return Ok("Hello World");
    }
    
    [HttpGet(Name = "GetWeatherForecast")]
    [Route("GetAllReviews")]
    public IEnumerable<Review> GetReviews()
    {
        return _repo.GetReviews();
    }
}