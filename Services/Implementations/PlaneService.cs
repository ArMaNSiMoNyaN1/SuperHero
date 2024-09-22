using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Services.Implementations;

public class PlaneService : IPlaneService
{
    private readonly DataContext _context;

    public PlaneService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Plane>> GetAll()
    {
        var planes = await _context.Planes.ToListAsync();
        return planes;
    }

    public async Task<Plane?> GetById(int id)
    {
        return await _context.Planes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Plane> Add(Plane plane)
    {
        var result = _context.Planes.Add(plane);
        await _context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public  async Task<Plane?> Update(Plane updatePlane)
    {
        var plane = await _context.Planes.FindAsync(updatePlane.Id);
        if (plane == null)
        {
            return null;
        }

        plane.Brand = updatePlane.Brand;
        plane.Model= updatePlane.Model;
        plane.Country= updatePlane.Country;
        _context.Planes.Update(plane);
        await _context.SaveChangesAsync();

        return plane;
    }

    public async Task<bool> Delete(int id)
    {
        var plane = await _context.Planes.FindAsync(id);
        if (plane is null) return false;

        _context.Planes.Remove(plane);
        await _context.SaveChangesAsync();
        return true;
    }
}