using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.Interfaces;

public interface IPlaneService
{
    Task<List<Plane>> GetAll();
    Task<Plane?> GetById(int id);
    Task<Plane> Add(Plane plane);
    Task<Plane?> Update(Plane updatePlane);
    Task<bool> Delete(int id);
}