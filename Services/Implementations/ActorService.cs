using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Services.Implementations;

public class ActorService : IActorService
{
    private readonly DataContext _context;

    public ActorService(DataContext context)
    {
        _context = context;
    }


    public async Task<List<Actor>> GetAll()
    {
        var actors = await _context.Actors.ToListAsync();
        return actors;
    }

    public async Task<Actor?> GetById(int id)
    {
        return await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Actor> Add(Actor actor)
    {
        var result = _context.Actors.Add(actor);
        await _context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public async Task<Actor?> Update(Actor updateActor)
    {
        var actor = await _context.Actors.FindAsync(updateActor.Id);
        if (actor == null) return null;
        
        actor.Name = updateActor.Name;
        actor.FirstName = updateActor.FirstName;
        actor.LastName = updateActor.LastName;
        actor.Place = updateActor.Place;
        _context.Actors.Update(actor);
        await _context.SaveChangesAsync();
        
        return actor;
    }

    public async Task<bool> Delete(int id)
    {
        var actor = await _context.Actors.FindAsync(id);
        if (actor is null) return false;

        _context.Actors.Remove(actor);
        await _context.SaveChangesAsync();
        return true;
    }
}