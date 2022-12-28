using MovieApp.Models;
using MovieApp.Models.ViewModel;
using MovieApp.Services.Interfaces;

namespace MovieApp.Services
{
    public class MovieService :  IMovieService
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

        public async Task<Movie> UpdateMovie(MovieDTO model)
        {
            //var b = _dbContext.Genres.FirstOrDefault(x => x.Description == model.Genre);
            
            var a= _dbContext.Movies.FirstOrDefault(x=>x.MovieId==model.MovieId);

            a.Name = model.Name;

            //a.Date = model.Date;

            //a.Genre = b;

            await _dbContext.SaveChangesAsync();

            return a;
        }

        public async Task<Movie> CreateMovie(MovieDTO model)
        {
            //var b = _dbContext.Genres.FirstOrDefault(x => x.Description == model.Genre);

            var a = _dbContext.Movies.FirstOrDefault(x => x.MovieId == model.MovieId);


            a.Name = model.Name;

            //a.Date = model.Date;

            //a.Genre = b;

            await _dbContext.SaveChangesAsync();

            return a;
        }


    }
}