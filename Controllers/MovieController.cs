using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Services.Interfaces;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet()]
        public List<Movie> Get()
        {
            return _movieService.GetMovies();
        }
    }
}