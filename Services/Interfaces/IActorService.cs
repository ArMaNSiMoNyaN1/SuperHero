using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.Interfaces;

public interface IActorService
{
    Task<List<Actor>> GetAll();
    Task<Actor?> GetById(int id);
    Task<Actor> Add(Actor actor);
    Task<Actor?> Update(Actor updateActor);
    Task<bool> Delete(int id);
}