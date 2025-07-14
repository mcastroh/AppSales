using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.DTOs;
using Country = Sales.Shared.Entities.Country;

namespace Sales.API.Controllers;

[ApiController]
[Route("/api/countries")]
public class CountriesController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CountriesController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        return Ok(await _context.Countries.Include(x => x.States).ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
        if (country is null) return NotFound();
        return Ok(country);
    }

    [HttpGet("full")]
    public async Task<ActionResult> GetAsyncFull()
    {
        return Ok(await _context.Countries.Include(x => x.States!).ThenInclude(x => x.Cities).ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CountryCreateDTO creationDTO)
    {
        var entity = _mapper.Map<Country>(creationDTO);
        _context.Add(entity);

        try
        {
            await _context.SaveChangesAsync();
            return Ok(entity);
        }
        catch (DbUpdateException dbUpdateException)
        {
            if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
            {
                return BadRequest("Ya existe un país con el mismo nombre.");
            }
            else
            {
                return BadRequest(dbUpdateException.InnerException.Message);
            }
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> PutAsync(int id, CountryCreateDTO creationDTO)
    {
        var entity = _mapper.Map<Country>(creationDTO);
        entity.Id = id;
        _context.Update(entity);

        try
        {
            await _context.SaveChangesAsync();
            return Ok(entity);
        }
        catch (DbUpdateException dbUpdateException)
        {
            if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
            {
                return BadRequest("Ya existe un registro con el mismo nombre.");
            }
            else
            {
                return BadRequest(dbUpdateException.InnerException.Message);
            }
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var entity = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null) return NotFound();
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}