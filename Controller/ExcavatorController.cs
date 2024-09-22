using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.ApiModel.Excavator;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class ExcavatorController : ControllerBase
{
    private readonly IExcavatorService _excavatorService;
    private readonly IMapper _mapper;

    public ExcavatorController(IExcavatorService excavatorService, IMapper mapper)
    {
        _excavatorService = excavatorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetExcavatorModel>>> GetAll()
    {
        var excavators = await _excavatorService.GetAll();
        var result = excavators.Select(x => _mapper.Map<GetExcavatorModel>(x)).ToList();
        return result;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdExcavatorModel>> GetById(int id)
    {
        var excavator = await _excavatorService.GetById(id);
        if (excavator is null) return NotFound();
        var result = _mapper.Map<GetByIdExcavatorModel>(excavator);
        return result;
    }

    [HttpPost]
    public async Task<ActionResult<GetByIdExcavatorModel>> Add(CreateExcavatorModel excavatorModel)
    {
        var excavator = _mapper.Map<Excavator>(excavatorModel);
        var newExcavator = await _excavatorService.Add(excavator);
        var result = _mapper.Map<GetByIdExcavatorModel>(newExcavator);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdExcavatorModel>> Update(UpdateExcavatorModel updateExcavatorModel)
    {
        var excavator = _mapper.Map<Excavator>(updateExcavatorModel);
        var updatedExcavatorModel = await _excavatorService.Update(excavator);
        if (updatedExcavatorModel is null) return NotFound();
        var excavatorModel = _mapper.Map<GetByIdExcavatorModel>(excavator);
        return Ok(excavatorModel);
    }
    [HttpPut]
    public async Task<ActionResult<GetByIdExcavatorModel>> Update(string name, UpdateExcavatorModel updateExcavatorModel)
    {
        var excavator = _mapper.Map<Excavator>(updateExcavatorModel);
        var updatedExcavatorModel = await _excavatorService.Update(excavator);
        if (updatedExcavatorModel is null) return NotFound();
        var excavatorModel = _mapper.Map<GetByIdExcavatorModel>(excavator);
        return Ok(excavatorModel);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _excavatorService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}