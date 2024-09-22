using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.ApiModel.Plane;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class PlaneController : ControllerBase
{
    private readonly IPlaneService _planeService;
    private readonly IMapper _mapper;

    public PlaneController(IPlaneService planeService, IMapper mapper)
    {
        _planeService = planeService;
        _mapper = mapper;
    }

    [HttpGet] 
    public async Task<ActionResult<List<GetPlaneModel>>> GetAll()
    {
        var planes = await _planeService.GetAll();
        var result = planes.Select(x => _mapper.Map<GetPlaneModel>(x)).ToList();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdPlaneModel>> GetById(int id)
    {
        var plane = await _planeService.GetById(id);
        if (plane is null) return NotFound();
        var result = _mapper.Map<GetPlaneModel>(plane);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetByIdPlaneModel>> Add(CreatePlaneModel plane)
    {
        var planes = _mapper.Map<Plane>(plane);
        var planeModel = await _planeService.Add(planes);
        var result = _mapper.Map<GetByIdPlaneModel>(planeModel);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdPlaneModel>> Update(UpdatePlaneModel updatePlaneModel)
    {
        var plane = _mapper.Map<Plane>(updatePlaneModel);
        var updatedPlane = await _planeService.Update(plane);
        if (updatedPlane is null) return NotFound();
        var result = _mapper.Map<GetByIdPlaneModel>(plane);
        return Ok(result);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _planeService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}