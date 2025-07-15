using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.DTOs;
using Sales.Shared.Entities;

namespace Sales.API.Controllers;

[ApiController]
[Route("/api/cities")]
public class CitiesController : ExtendedBaseController<CityCreateDTO, City, CityDTO>
{
    private readonly DataContext _context;

    public CitiesController(DataContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("combo/{stateId:int}")]
    public async Task<ActionResult<List<City>>> GetCombo(int stateId)
    {
        var cities = await _context.Cities.Include(x => x.State).Where(x => x.StateId == stateId).ToListAsync();
        return Ok(cities);
    }

    [HttpGet("{id}")]
    public override async Task<ActionResult<City>> GetByIdAsync(int id)
    {
        var entity = await _context.Cities.Include(x => x.State).FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) return NotFound();
        return entity;
    }
}