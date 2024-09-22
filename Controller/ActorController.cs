using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.ApiModel.Actor;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class ActorController : ControllerBase
{
    private readonly IActorService _actorService;
    private readonly IMapper _mapper;

    public ActorController(IActorService actorService, IMapper mapper)
    {
        _actorService = actorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetActorModel>>> GetAll()
    {
        var actors = await _actorService.GetAll();
        var result = actors.Select(x => _mapper.Map<GetActorModel>(x)).ToList();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdActorModel>> GetById(int id)
    {
        var actor = await _actorService.GetById(id);
        if (actor is null) return NotFound();
        var result = _mapper.Map<GetByIdActorModel>(actor);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetByIdActorModel>> Add(CreateActorModel actorModel)
    {
        var actor = _mapper.Map<Actor>(actorModel);
        var newActor = await _actorService.Add(actor);
        var result = _mapper.Map<GetByIdActorModel>(newActor);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdActorModel>> Update(UpdateActorModel updateActorModel)
    {
        var actor = _mapper.Map<Actor>(updateActorModel);
        var updatedActor = await _actorService.Update(actor);
        if (updatedActor == null) return NotFound();
        var actorModel = _mapper.Map<GetByIdActorModel>(actor);
        return Ok(actorModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _actorService.Delete(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}