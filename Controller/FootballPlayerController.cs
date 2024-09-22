using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.ApiModel.FootballPlayer;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;


namespace SuperHeroAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class FootballPlayerController : ControllerBase
{
    private readonly IFootballPlayerService _footballPlayerService;
    private readonly IMapper _mapper;

    public FootballPlayerController(IFootballPlayerService footballPlayerService, IMapper mapper)
    {
        _footballPlayerService = footballPlayerService;
        _mapper = mapper;
    }

    [HttpGet] 
    public async Task<ActionResult<List<GetFootballPlayerModel>>> GetAll()
    {
        var footballPlayers = await _footballPlayerService.GetAll();
        var result = footballPlayers.Select(x => _mapper.Map
            <GetFootballPlayerModel>(x)).ToList();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdFootballPlayerModel>> GetById(int id)
    {
        var footballPlayer = await _footballPlayerService.GetById(id);
        if (footballPlayer is null) return NotFound();
        var result = _mapper.Map<GetByIdFootballPlayerModel>(footballPlayer);
        return Ok(result);
    }

    [HttpPost] 
    public async Task<ActionResult<GetByIdFootballPlayerModel>> Add(CreateFootballPlayerModel footballPlayerModel)
    {
        var footballPlayer = _mapper.Map<FootballPlayer>(footballPlayerModel);
        var newFootballPlayer = await _footballPlayerService.Add(footballPlayer);
        var result = _mapper.Map<GetByIdFootballPlayerModel>(newFootballPlayer);
        return Ok(result);
    }

    [HttpPut] 
    public async Task<ActionResult<GetByIdFootballPlayerModel>> Update(
        UpdateFootballPlayerModel updateFootballPlayerModel){
        var footballPlayer = _mapper.Map<FootballPlayer>(updateFootballPlayerModel);
        var updatedFootballPlayerModel = await _footballPlayerService.Update(footballPlayer);
        if (updatedFootballPlayerModel == null) return NotFound();
        var footballPlayerModel = _mapper.Map<GetByIdFootballPlayerModel>(footballPlayer);
        return Ok(footballPlayerModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _footballPlayerService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}