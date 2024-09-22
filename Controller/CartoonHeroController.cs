using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.ApiModel.CartoonHero;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Services.Interfaces;

namespace SuperHeroAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class CartoonHeroController : ControllerBase
{
    private readonly ICartoonHeroService _cartoonHeroService;
    private readonly IMapper _mapper;

    public CartoonHeroController(ICartoonHeroService cartoonHeroService, IMapper mapper)
    {
        _cartoonHeroService = cartoonHeroService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetCartoonHeroModel>>> GetAll()
    {
        var cartoonHeroes = await _cartoonHeroService.GetAll();
        var result = cartoonHeroes.Select(x => _mapper.Map
            <GetCartoonHeroModel>(x)).ToList();
        return Ok(result);
    }

    [HttpGet] 
    [Route("{id}")]
    public async Task<ActionResult<GetByIdCartoonHeroModel>> GetById(int id)
    {
        var hero = await _cartoonHeroService.GetById(id);
        if (hero is null) return NotFound();
        var result = _mapper.Map<GetByIdCartoonHeroModel>(hero);
        return Ok(result);
    }

    [HttpPost]  
    public async Task<ActionResult<GetByIdCartoonHeroModel>> Add(CreateCartoonHeroModel cartoonHeroModel)
    {
        var cartoonHero = _mapper.Map<CartoonHero>(cartoonHeroModel);
        var newCartoonHero = await _cartoonHeroService.Add(cartoonHero);
        var result = _mapper.Map<GetByIdCartoonHeroModel>(newCartoonHero);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdCartoonHeroModel>> Update(UpdateCartoonHeroModel updateCartoonHeroModel)
    {
        var cartonHero = _mapper.Map<CartoonHero>(updateCartoonHeroModel);
        var updatedCartoonHero = await _cartoonHeroService.Update(cartonHero);
        if (updatedCartoonHero == null) return NotFound();
        var cartoonHeroModel = _mapper.Map<GetByIdCartoonHeroModel>(cartonHero);
        return Ok(cartoonHeroModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _cartoonHeroService.Delete(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}