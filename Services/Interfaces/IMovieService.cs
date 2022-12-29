using MovieApp.Models;
using MovieApp.Models.Core;
using MovieApp.Models.ViewModel;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        Task<Result<List<MovieDTO>>> GetMovies();
        Task<Result<Movie>> UpdateMovie(MovieDTO model);
        Task<Result<Movie>> CreateMovie(MovieDTO model);
        //todo: remove generic parameter
        Task<Result<Movie>> DeleteMovie(int movieId);
    }
}
