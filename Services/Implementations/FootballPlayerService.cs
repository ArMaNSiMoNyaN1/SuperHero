using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Services.Implementations;

public class FootballPlayerService : IFootballPlayerService
{
    private readonly DataContext _context;

    public FootballPlayerService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<FootballPlayer>> GetAll()
    {
        var footballPlayers = await _context.FootballPlayers.ToListAsync();
        return footballPlayers;
    }

    public async Task<FootballPlayer?> GetById(int id)
    {
        return await _context.FootballPlayers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<FootballPlayer> Add(FootballPlayer footballPlayer)
    {
        var result = _context.FootballPlayers.Add(footballPlayer);
        await _context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public async Task<FootballPlayer?> Update(FootballPlayer updateFootballPlayer)
    {
        var footballPlayer = await _context.FootballPlayers.FindAsync(updateFootballPlayer.Id);
        if (footballPlayer == null)
        {
            return null;
        }
        footballPlayer.Name = updateFootballPlayer.Name;
        footballPlayer.Place = updateFootballPlayer.Place;
        footballPlayer.FirstName = updateFootballPlayer.FirstName;
        footballPlayer.LastName = updateFootballPlayer.LastName;
        _context.FootballPlayers.Update(footballPlayer);
        await _context.SaveChangesAsync();

        return footballPlayer;
    }

    public async Task<bool> Delete(int id)
    {
        var footballPlayer = await _context.FootballPlayers.FindAsync(id);
        if (footballPlayer is null) return false;

        _context.FootballPlayers.Remove(footballPlayer);
        await _context.SaveChangesAsync();
        return true;
    }
}