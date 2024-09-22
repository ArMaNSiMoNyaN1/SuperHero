using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Services.Implementations;

public class CarService : ICarService
{
    private readonly DataContext _context;

    public CarService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetAll()
    {
        var cars = await _context.Car.ToListAsync();
        return cars;
    }

    public async Task<Car?> GetById(int id)
    {
        return await _context.Car.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Car> Add(Car car)
    {
        var result = _context.Car.Add(car);
        await _context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public async Task<Car?> Update(Car updateCar)
    {
        var car = await _context.Car.FindAsync(updateCar.Id);
        {
            if (car is null) return null;

            car.Id = updateCar.Id;
            car.Brand = updateCar.Brand;
            car.Model = updateCar.Model;
            car.Country = updateCar.Country;

            _context.Car.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var car = await _context.Car.FindAsync(id);
        if (car is null) return false;

        _context.Car.Remove(car);
        await _context.SaveChangesAsync();
        return true;
    }
}