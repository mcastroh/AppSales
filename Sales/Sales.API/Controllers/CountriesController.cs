using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.API.Migrations;
using Sales.Shared.DTOs;

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
    public async Task<ActionResult> Get()
    {
        return Ok(await _context.Countries.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromForm] CountryCreateDTO creationDTO)
    {
        var entity = _mapper.Map<Country>(creationDTO);
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return Ok(entity);
    }
}