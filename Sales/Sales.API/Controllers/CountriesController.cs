using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.API.Migrations;
using Sales.Shared.DTOs;
using Sales.Shared.Entities;
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
        return Ok(await _context.Countries.ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetAsync(int id)
    {
        var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
        if (country is null) return NotFound();
        return Ok(country);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CountryCreateDTO creationDTO)
    {
        //var entity = _mapper.Map<Country>(creationDTO);
        //public TDestination Map<TDestination>(object source) => Map(source, default(TDestination));
        //_context.Add(entity);
        //await _context.SaveChangesAsync();
        //return Ok(entity);

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
        //var entity = _mapper.Map<Country>(creationDTO);
        //entity.Id = id;

        //_context.Update(entity);

        //await _context.SaveChangesAsync();
        //return Ok(entity);

        var entity = _mapper.Map<Country>(creationDTO);
        entity.Id = id;

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
        //var afectedRows = await _context.Countries.Where(x => x.Id == id).ExecuteDeleteAsync();
        //if (afectedRows == 0) return NotFound();
        //return NoContent();

        var entity = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null) return NotFound();
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}