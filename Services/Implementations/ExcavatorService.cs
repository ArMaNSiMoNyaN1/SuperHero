using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Services.Implementations;

public class ExcavatorService : IExcavatorService
{
    private readonly DataContext _context;

    public ExcavatorService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Excavator>> GetAll()
    {
        var excavators = await _context.Excavators.ToListAsync();
        return excavators;
    }

    public async Task<Excavator?> GetById(int id)
    {
        return await _context.Excavators.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Excavator> Add(Excavator excavator)
    {
        var result = _context.Excavators.Add(excavator);
        await _context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public Task<Excavator?> Update(Excavator excavator)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(int id)
    {
        var excavator = await _context.Excavators.FindAsync(id);
        if (excavator is null) return false;
        _context.Excavators.Remove(excavator);
        await _context.SaveChangesAsync();
        return true;
    }
}