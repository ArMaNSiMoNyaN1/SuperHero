using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.Interfaces;

public interface IExcavatorService
{
    Task<List<Excavator>> GetAll();

    Task<Excavator?> GetById(int id);

    Task<Excavator> Add(Excavator excavator);

    Task<Excavator?> Update(Excavator excavator);

    Task<bool> Delete(int id);
}