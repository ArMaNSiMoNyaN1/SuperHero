using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.Interfaces;

public interface ICartoonHeroService
{
    Task<List<CartoonHero>> GetAll();
    Task<CartoonHero?> GetById(int id);
    Task<CartoonHero> Add(CartoonHero cartoonHero);
    Task<CartoonHero?> Update(CartoonHero updateCartoonHero);
    Task<bool> Delete(int id);
}