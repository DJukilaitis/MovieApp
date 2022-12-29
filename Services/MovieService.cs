using MovieApp.Models;
using MovieApp.Models.Core;
using MovieApp.Models.ViewModel;
using MovieApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieAppDbContext _dbContext;

        public MovieService(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<List<MovieDTO>>> GetMovies()
        {
            var movies = await _dbContext.Movies.Select(x => new MovieDTO
            {
                MovieId = x.MovieId,
                LeadActor = x.LeadActor.Name,
                Genre = x.Genre.Description,
                Date = x.Date,
                Description = x.Description,
                Name = x.Name,
            }).ToListAsync();

            try
            {
                return Result<List<MovieDTO>>.Success(movies);
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<List<MovieDTO>>.Fail("Something wrong happened while retrieving movies. Try again later");
            }
        }

        public async Task<Result<Movie>> UpdateMovie(MovieDTO model)
        {
            try
            {
                var genre = _dbContext.Genres.FirstOrDefault(x => x.Description == model.Genre);
                var actor = _dbContext.Actors.FirstOrDefault(x => x.Name == model.LeadActor);
                var genre2 = new Genre { };
                var actor2 = new Actor { };

                if (genre == null)
                {
                    genre2 = new Genre
                    {
                        Description = model.Genre
                    };

                    _dbContext.Genres.Add(genre2);
                    await _dbContext.SaveChangesAsync();
                    genre = genre2;

                    //return Result<Movie>.Fail("Genre does not exist");
                }

                if (actor == null)
                {
                    actor2 = new Actor
                    {
                        Name = model.LeadActor
                    };

                    _dbContext.Actors.Add(actor2);
                    await _dbContext.SaveChangesAsync();
                    actor = actor2;

                    //return Result<Movie>.Fail("Actor does not exist");
                }

                var movie = _dbContext.Movies.FirstOrDefault(x => x.MovieId == model.MovieId);

                if (movie == null)
                {
                    return Result<Movie>.Fail("Movie does not exist");
                }

                movie.Name = model.Name;
                movie.Date = model.Date;
                movie.Description = model.Description;
                movie.Genre = genre;
                movie.LeadActor = actor;

                await _dbContext.SaveChangesAsync();
                return Result<Movie>.Success(movie);
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<Movie>.Fail("Something wrong happened while updating a movie. Try again later");
            }
        }

        public async Task<Result<Movie>> CreateMovie(MovieDTO model)
        {
            try
            {
                var genre = _dbContext.Genres.FirstOrDefault(x => x.Description == model.Genre);
                var actor = _dbContext.Actors.FirstOrDefault(x => x.Name == model.LeadActor);

                var genre2 = new Genre { };
                var actor2 = new Actor { };


                if (genre == null)
                {
                    genre2 = new Genre
                    {
                        Description = model.Genre
                    };

                    _dbContext.Genres.Add(genre2);
                    await _dbContext.SaveChangesAsync();
                    genre = genre2;

                    //return Result<Movie>.Fail("Genre does not exist");
                }



                if (actor == null)
                {
                    actor2 = new Actor
                    {
                        Name = model.LeadActor
                    };

                    _dbContext.Actors.Add(actor2);
                    await _dbContext.SaveChangesAsync();
                    actor = actor2;

                    //return Result<Movie>.Fail("Actor does not exist");
                }

                var movie = new Movie
                {
                    Date = model.Date,
                    Description = model.Description,
                    Genre = genre,
                    Name = model.Name,
                    LeadActor = actor,
                };

                //error handling actor

                _dbContext.Movies.Add(movie);
                await _dbContext.SaveChangesAsync();

                return Result<Movie>.Success(movie);
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<Movie>.Fail("Something wrong happened while saving. Try again later");
            }
        }

        public async Task<Result<Movie>> DeleteMovie(int movieId)
        {
            try
            {
                var movie = _dbContext.Movies.FirstOrDefault(x => x.MovieId == movieId);

                if (movie == null)
                {
                    return Result<Movie>.Fail("Movie does not exist");
                }

                _dbContext.Movies.Remove(movie);
                await _dbContext.SaveChangesAsync();
                return Result<Movie>.Success(movie);
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<Movie>.Fail("Something wrong happened while deleting a movie. Try again later");
            }
        }


    }
}