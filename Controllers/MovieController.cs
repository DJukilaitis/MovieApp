using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Models.ViewModel;
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

        [HttpPut()]
        public Movie Update(MovieDTO model)
        {
            _movieService.UpdateMovie(model);
            return null;
        }
    }
}