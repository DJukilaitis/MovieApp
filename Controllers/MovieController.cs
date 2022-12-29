using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var moviesResult = await _movieService.GetMovies();
            return moviesResult.GetResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieDTO model)
        {
            var createResult = await _movieService.CreateMovie(model);
            return createResult.GetResult();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(MovieDTO model)
        {
            var updateResult = await _movieService.UpdateMovie(model);
            return updateResult.GetResult();
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> Delete(int movieId)
        {
            var deleteResult = await _movieService.DeleteMovie(movieId);
            return deleteResult.GetResult();
        }
    }
}