using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Interfaces;

namespace Sales.API.Controllers;

public class ExtendedBaseController<TCreation, TEntity, TDTO> : ControllerBase where TEntity : class, IHaveId
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ExtendedBaseController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public virtual async Task<ActionResult<List<TEntity>>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TEntity>> GetByIdAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) return NotFound();
        return entity;
    }

    [HttpPost]
    public virtual async Task<IActionResult> PostAsync(TCreation creation)
    {
        var entity = _mapper.Map<TEntity>(creation);
        await _context.AddAsync(entity);

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

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> PutAsync(int id, TCreation creation)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) return NotFound();
        _mapper.Map(creation, entity);
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

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) return NotFound();

        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}