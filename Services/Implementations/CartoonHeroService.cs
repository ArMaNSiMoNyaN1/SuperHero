using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Services.Implementations;

public class CartoonHeroService : ICartoonHeroService
{
    private readonly DataContext _context;

    public CartoonHeroService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<CartoonHero>> GetAll()
    {
        var cartoonHeroes = await _context.CartoonHeroes.ToListAsync();
        return cartoonHeroes;
    }

    public async Task<CartoonHero?> GetById(int id)
    {
        return await _context.CartoonHeroes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<CartoonHero> Add(CartoonHero cartoonHero)
    {
        var result = _context.CartoonHeroes.Add(cartoonHero);
        await _context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public async Task<CartoonHero?> Update(CartoonHero updateCartoonHero)
    {
        var cartoonHero = await _context.CartoonHeroes.FindAsync(updateCartoonHero.Id);
        if (cartoonHero == null)
        {
            return null;
        }
        cartoonHero.Name = updateCartoonHero.Name;
        cartoonHero.Place = updateCartoonHero.Place;
        cartoonHero.FirstName = updateCartoonHero.FirstName;
        cartoonHero.LastName = updateCartoonHero.LastName;
        _context.CartoonHeroes.Update(cartoonHero);
        await _context.SaveChangesAsync();

        return cartoonHero;
    }

    public async Task<bool> Delete(int id)
    {
        var cartoonHero = await _context.CartoonHeroes.FindAsync(id);
        if (cartoonHero is null)
            return false;

        _context.CartoonHeroes.Remove(cartoonHero);
        await _context.SaveChangesAsync();

        return true;
    }
}