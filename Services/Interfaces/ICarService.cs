using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.Interfaces;

public interface ICarService
{
    Task<List<Car>> GetAll();
    Task<Car?> GetById(int id);
    Task<Car> Add(Car car);
    Task<Car?> Update(Car updateCar);
    Task<bool> Delete(int id);
}