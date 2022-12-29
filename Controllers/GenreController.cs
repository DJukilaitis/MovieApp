using Microsoft.AspNetCore.Mvc;
using MovieApp.Models.ViewModel;
using MovieApp.Services.Interfaces;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        
        private readonly ILogger<GenreController> _logger;
        private readonly IGenreService _genreService;

        public GenreController(ILogger<GenreController> logger, IGenreService movieService)
        {
            _logger = logger;
            _genreService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var retrieveResult = await _genreService.GetGenres();
            return retrieveResult.GetResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreDTO model)
        {
            var createResult = await _genreService.CreateGenre(model);
            return createResult.GetResult();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(GenreDTO model)
        {
            var updateResult = await _genreService.UpdateGenre(model);
            return updateResult.GetResult();
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> Delete(int movieId)
        {
            var deleteResult = await _genreService.DeleteGenre(movieId);
            return deleteResult.GetResult();
        }
    }
}