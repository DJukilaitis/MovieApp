using Microsoft.AspNetCore.Mvc;
using MovieApp.Models.ViewModel;
using MovieApp.Services.Interfaces;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        
        private readonly ILogger<ActorController> _logger;
        private readonly IActorService _actorService;

        public ActorController(ILogger<ActorController> logger, IActorService movieService)
        {
            _logger = logger;
            _actorService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var retrieveResult = await _actorService.GetActors();
            return retrieveResult.GetResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorDTO model)
        {
            var createResult = await _actorService.CreateActor(model);
            return createResult.GetResult();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(ActorDTO model)
        {
            var updateResult = await _actorService.UpdateActor(model);
            return updateResult.GetResult();
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> Delete(int movieId)
        {
            var deleteResult = await _actorService.DeleteActor(movieId);
            return deleteResult.GetResult();
        }
    }
}