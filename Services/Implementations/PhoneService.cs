using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Services.Implementations;

public class PhoneService : IPhoneService
{
    private readonly DataContext _context;

    public PhoneService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Phone>> GetAll()
    {
        var phones = await _context.Phone.ToListAsync();
        return phones;
    }

    public async Task<Phone?> GetById(int id)
    {
        return await _context.Phone.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Phone> Add(Phone phone)
    {
        var result = _context.Phone.Add(phone);
        await _context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public async Task<Phone?> Update(Phone updatePhone)
    {
        var phone = await _context.Phone.FindAsync(updatePhone.Id);
        if (phone is null) return null;

        phone.Id = updatePhone.Id;
        phone.Brand = updatePhone.Brand;
        phone.Model = updatePhone.Model;
        phone.Country = updatePhone.Country;
        _context.Phone.Update(phone);
        await _context.SaveChangesAsync();
        return phone;
    }

    public async Task<bool> Delete(int id)
    {
        var phone = await _context.Phone.FindAsync(id);
        if (phone is null) return false;

        _context.Phone.Remove(phone);
        await _context.SaveChangesAsync();
        return true;
    }
}