using MovieApp.Models;
using MovieApp.Models.Core;
using MovieApp.Models.ViewModel;

namespace MovieApp.Services.Interfaces
{
    public interface IActorService
    {
        Task<Result<List<Actor>>> GetActors();
        Task<Result<Actor>> UpdateActor(ActorDTO model);
        Task<Result<Actor>> CreateActor(ActorDTO model);
        
        //todo: remove generic parameter
        Task<Result<Actor>> DeleteActor(int actorId);
    }
}
