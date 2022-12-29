using System.Data.Entity;
using MovieApp.Models;
using MovieApp.Models.Core;
using MovieApp.Models.ViewModel;
using MovieApp.Services.Interfaces;

namespace MovieApp.Services
{
    public class GenreService : IGenreService
    {
        private readonly MovieAppDbContext _dbContext;

        public GenreService(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<List<Genre>>> GetGenres()
        {
            try
            {
                return Result<List<Genre>>.Success( _dbContext.Genres.ToList());
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<List<Genre>>.Fail("Something wrong happened while retrieving genres. Try again later");
            }
        }

        public async Task<Result<Genre>> UpdateGenre(GenreDTO model)
        {
            try
            {
                var genre = _dbContext.Genres.FirstOrDefault(x => x.GenreId == model.GenreID);

                if (genre == null)
                {
                    return Result<Genre>.Fail("Genre does not exist");
                }

                var isExistingGenre = _dbContext.Genres.Any(x => x.Description == model.Name);

                if (isExistingGenre)
                {
                    return Result<Genre>.Fail("Genre with that name already exists");
                }
                
                genre.Description = model.Name;

                await _dbContext.SaveChangesAsync();
                return Result<Genre>.Success(genre);
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<Genre>.Fail("Something wrong happened while updating a genre. Try again later");
            }
        }

        public async Task<Result<Genre>> CreateGenre(GenreDTO model)
        {
            try
            {
                var isExistingGenre = _dbContext.Genres.Any(x => x.Description == model.Name);

                if (isExistingGenre)
                {
                    return Result<Genre>.Fail("Genre already exists");
                }
                
                var genre = new Genre
                {
                    Description = model.Name
                };

                _dbContext.Genres.Add(genre);
                await _dbContext.SaveChangesAsync();
                return Result<Genre>.Success(genre);
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<Genre>.Fail("Something wrong happened while saving. Try again later");
            }
        }

        public async Task<Result<Genre>> DeleteGenre(int genreId)
        {
            try
            {
                var genre = _dbContext.Genres.FirstOrDefault(x => x.GenreId == genreId);

                if (genre == null)
                {
                    return Result<Genre>.Fail("Genre does not exist");
                }

                _dbContext.Genres.Remove(genre);
                await _dbContext.SaveChangesAsync();
                return Result<Genre>.Success(genre);
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<Genre>.Fail("Something wrong happened while deleting an genre. Try again later");
            }
        }
    }
}