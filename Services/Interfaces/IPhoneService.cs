using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Services.Interfaces;

public interface IPhoneService
{
    Task<List<Phone>> GetAll();
    Task<Phone?> GetById(int id);
    Task<Phone> Add(Phone phone);
    Task<Phone?> Update(Phone updatePhone);
    Task<bool> Delete(int id);
}