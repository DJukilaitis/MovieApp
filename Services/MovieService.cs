using MovieApp.Models;
using MovieApp.Services.Interfaces;

namespace MovieApp.Services
{
    public class MovieService : IMovieService
    {
        MovieAppDbContext _dbContext;

        public MovieService(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movie> GetMovies()
        {
            return _dbContext.Movies.ToList();
        }
    }
}