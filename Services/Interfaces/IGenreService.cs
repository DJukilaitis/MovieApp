using MovieApp.Models;
using MovieApp.Models.Core;
using MovieApp.Models.ViewModel;

namespace MovieApp.Services.Interfaces
{
    public interface IGenreService
    {
        Task<Result<List<Genre>>> GetGenres();
        Task<Result<Genre>> UpdateGenre(GenreDTO model);
        Task<Result<Genre>> CreateGenre(GenreDTO model);
        
        //todo: remove generic parameter
        Task<Result<Genre>> DeleteGenre(int actorId);
    }
}
