using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly FleetDbContext _db;
    public DriversController(FleetDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Driver>>> Get([FromQuery] string? q)
    {
        var query = _db.Drivers.AsQueryable();
        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(d => d.FullName.Contains(q) || d.LicenseNumber.Contains(q));
        var list = await query.OrderBy(d => d.FullName).ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Driver>> GetById(int id)
    {
        var d = await _db.Drivers.FindAsync(id);
        return d is null ? NotFound() : Ok(d);
    }

    [HttpPost]
    public async Task<ActionResult<Driver>> Create(Driver d)
    {
        _db.Drivers.Add(d);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = d.Id }, d);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Driver input)
    {
        if (id != input.Id) return BadRequest();
        _db.Entry(input).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var d = await _db.Drivers.FindAsync(id);
        if (d is null) return NotFound();
        _db.Drivers.Remove(d);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}