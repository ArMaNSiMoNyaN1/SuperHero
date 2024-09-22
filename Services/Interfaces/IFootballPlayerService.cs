using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.Interfaces;

public interface IFootballPlayerService
{
    Task<List<FootballPlayer>> GetAll();
    Task<FootballPlayer?> GetById(int id);
    Task<FootballPlayer> Add(FootballPlayer footballPlayer);
    Task<FootballPlayer?> Update(FootballPlayer footballPlayer);
    Task<bool> Delete(int id);
}