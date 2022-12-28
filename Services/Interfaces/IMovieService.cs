using MovieApp.Models;
using MovieApp.Models.ViewModel;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        Task<Movie> UpdateMovie(MovieDTO model);

    }
}
