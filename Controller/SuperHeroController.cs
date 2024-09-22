using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.ApiModel.SuperHero;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly ISuperHeroService _superHeroService;
    private readonly IMapper _mapper;

    public SuperHeroController(ISuperHeroService superHeroService, IMapper mapper)
    {
        _superHeroService = superHeroService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetSuperHeroModel>>> GetAll()
    {
        var superHeroes = await _superHeroService.GetAll();
        var result = superHeroes.Select(x => _mapper.Map
            <GetSuperHeroModel>(x)).ToList();
        return Ok(result);
    }


    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdSuperHeroModel>> GetById(int id)
    {
        var superHero = await _superHeroService.GetById(id);
        if (superHero is null) return NotFound();
        var result = _mapper.Map<GetByIdSuperHeroModel>(superHero);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetByIdSuperHeroModel>> Add(CreateSuperHeroModel hero)
    {
        var superHero = _mapper.Map<SuperHero>(hero);
        var newSuperHero = await _superHeroService.Add(superHero);
        var result = _mapper.Map<GetByIdSuperHeroModel>(newSuperHero);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdSuperHeroModel>> Update(UpdateSuperHeroModel updateSuperHeroModel)
    {
        var superHero = _mapper.Map<SuperHero>(updateSuperHeroModel);
        var updatedSuperHero = await _superHeroService.Update(superHero);
        if (updatedSuperHero == null) return NotFound();
        var updatedSuperHeroModel = _mapper.Map<GetByIdSuperHeroModel>(superHero);
        return Ok(updatedSuperHeroModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _superHeroService.Delete(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}