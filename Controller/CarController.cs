using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.ApiModel.Car;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly IMapper _mapper;

    public CarController(ICarService carService, IMapper mapper)
    {
        _carService = carService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetCarModel>>> GetAll()
    {
        var cars = await _carService.GetAll();
        var result = cars.Select(x => _mapper.Map<GetCarModel>(x)).ToList();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdCarModel>> GetById(int id)
    {
        var car = await _carService.GetById(id);
        if (car is null) return NotFound();
        var result = _mapper.Map<GetByIdCarModel>(car);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetByIdCarModel>> Add(CreateCarModel carModel)
    {
        var car = _mapper.Map<Car>(carModel);
        var newCar = await _carService.Add(car);
        var result = _mapper.Map<GetByIdCarModel>(newCar);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdCarModel>> Update(UpdateCarModel updateCarModel)
    {
        var car = _mapper.Map<Car>(updateCarModel);
        var updatedCarModel = await _carService.Update(car);
        if (updatedCarModel is null) return NotFound();
        var carModel = _mapper.Map<GetByIdCarModel>(car);
        return Ok(carModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _carService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}