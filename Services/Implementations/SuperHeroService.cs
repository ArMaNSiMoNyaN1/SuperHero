using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Services.Implementations;

public class SuperHeroService : ISuperHeroService
{
    private readonly DataContext _context;

    public SuperHeroService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<SuperHero>> GetAll()
    {
        var superHeroes = await _context.SuperHeroes.ToListAsync();
        return superHeroes;
    }

    public async Task<SuperHero?> GetById(int id)
    {
        return await _context.SuperHeroes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<SuperHero> Add(SuperHero superHero)
    {
        var result = _context.SuperHeroes.Add(superHero);
        await _context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public async Task<SuperHero?> Update(SuperHero updateSuperHero)
    {
        var superHero = await _context.SuperHeroes.FindAsync(updateSuperHero.Id);
        if (superHero == null)
        {
            return null;
        }

        superHero.Name = updateSuperHero.Name;
        superHero.Place = updateSuperHero.Place;
        superHero.FirstName = updateSuperHero.FirstName;
        superHero.LastName = updateSuperHero.LastName;
        _context.SuperHeroes.Update(superHero);
        await _context.SaveChangesAsync();

        return superHero;
    }

    public async Task<bool> Delete(int id)
    {
        var superHero = await _context.SuperHeroes.FindAsync(id);
        if (superHero is null) return false;

        _context.SuperHeroes.Remove(superHero);
        await _context.SaveChangesAsync();

        return true;
    }
}