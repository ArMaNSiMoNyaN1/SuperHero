using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.Interfaces;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetAll();
    Task<SuperHero?> GetById(int id);
    Task<SuperHero> Add(SuperHero superHero);
    Task<SuperHero?> Update(SuperHero updateSuperHero);
    Task<bool> Delete(int id);
}