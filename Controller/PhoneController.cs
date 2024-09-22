using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.ApiModel.Phone;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class PhoneController : ControllerBase
{
    private readonly IPhoneService _phoneService;
    private readonly IMapper _mapper;

    public PhoneController(IPhoneService phoneService, IMapper mapper)
    {
        _phoneService = phoneService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetPhoneModel>>> GetAll()
    {
        var phones = await _phoneService.GetAll();
        var result = phones.Select(x => _mapper.Map<GetPhoneModel>(x)).ToList();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdPhoneModel>> GetById(int id)
    {
        var phone = await _phoneService.GetById(id);
        if (phone is null) return NotFound();
        var result = _mapper.Map<GetByIdPhoneModel>(phone);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetByIdPhoneModel>> Add(CreatePhoneModel phoneModel)
    {
        var phone = _mapper.Map<Phone>(phoneModel);
        var newPhone = await _phoneService.Add(phone);
        var result = _mapper.Map<GetByIdPhoneModel>(newPhone);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdPhoneModel>> Update(UpdatePhoneModel updatePhoneModel)
    {
        var phone = _mapper.Map<Phone>(updatePhoneModel);
        var updatedPhone = await _phoneService.Update(phone);
        if (updatedPhone is null) return NotFound();
        var phoneModel = _mapper.Map<GetByIdPhoneModel>(phone);
        return Ok(phoneModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _phoneService.Delete(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}