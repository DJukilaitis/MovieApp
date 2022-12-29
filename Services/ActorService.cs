using System.Data.Entity;
using MovieApp.Models;
using MovieApp.Models.Core;
using MovieApp.Models.ViewModel;
using MovieApp.Services.Interfaces;

namespace MovieApp.Services
{
    public class ActorService : IActorService
    {
        private readonly MovieAppDbContext _dbContext;

        public ActorService(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<List<Actor>>> GetActors()
        {
            try
            {
                return Result<List<Actor>>.Success( _dbContext.Actors.ToList());
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<List<Actor>>.Fail("Something wrong happened while retrieving actors. Try again later");
            }
        }

        public async Task<Result<Actor>> UpdateActor(ActorDTO model)
        {
            try
            {
                var actor = _dbContext.Actors.FirstOrDefault(x => x.ActorId == model.ActorId);

                if (actor == null)
                {
                    return Result<Actor>.Fail("Actor does not exist");
                }

                actor.Name = model.Name;
                
                await _dbContext.SaveChangesAsync();
                return Result<Actor>.Success(actor);
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<Actor>.Fail("Something wrong happened while updating an actor. Try again later");
            }
        }

        public async Task<Result<Actor>> CreateActor(ActorDTO model)
        {
            try
            {
                var isExistingActor = _dbContext.Actors.Any(x => x.Name == model.Name);

                if (isExistingActor)
                {
                    return Result<Actor>.Fail("Actor already exists");
                }
                
                var actor = new Actor
                {
                    Name = model.Name
                };

                _dbContext.Actors.Add(actor);
                await _dbContext.SaveChangesAsync();
                return Result<Actor>.Success(actor);
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<Actor>.Fail("Something wrong happened while saving. Try again later");
            }
        }

        public async Task<Result<Actor>> DeleteActor(int actorId)
        {
            try
            {
                var actor = _dbContext.Actors.FirstOrDefault(x => x.ActorId == actorId);

                if (actor == null)
                {
                    return Result<Actor>.Fail("Actor does not exist");
                }

                _dbContext.Actors.Remove(actor);
                await _dbContext.SaveChangesAsync();
                return Result<Actor>.Success(actor);
            }
            catch (Exception ex)
            {
                // inject logger to log ex
                return Result<Actor>.Fail("Something wrong happened while deleting an actor. Try again later");
            }
        }
    }
}