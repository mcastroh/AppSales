using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.DTOs;
using Sales.Shared.Entities;

namespace Sales.API.Controllers;

[ApiController]
[Route("/api/states")]
public class StateController : ExtendedBaseController<StateCreateDTO, State, StateDTO>
{
    private readonly DataContext _context;

    public StateController(DataContext context, IMapper mapper) : base(context, mapper)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("combo/{countryId:int}")]
    public async Task<ActionResult> GetCombo(int countryId)
    {
        return Ok(await _context.States
            .Where(x => x.CountryId == countryId)
            .ToListAsync());
    }

    [HttpGet("item/{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var state = await _context.States.Include(x => x.Cities).FirstOrDefaultAsync(x => x.Id == id);
        if (state == null) return NotFound();
        return Ok(state);
    }
}