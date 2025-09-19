using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly FleetDbContext _db;
    public VehiclesController(FleetDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> Get([FromQuery] string? plate)
    {
        var q = _db.Vehicles.AsQueryable();
        if (!string.IsNullOrWhiteSpace(plate)) q = q.Where(v => v.PlateNumber.Contains(plate));
        var list = await q.OrderBy(v => v.PlateNumber).ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Vehicle>> GetById(int id)
    {
        var v = await _db.Vehicles.FindAsync(id);
        return v is null ? NotFound() : Ok(v);
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> Create(Vehicle v)
    {
        _db.Vehicles.Add(v);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = v.Id }, v);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Vehicle input)
    {
        if (id != input.Id) return BadRequest();
        _db.Entry(input).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var v = await _db.Vehicles.FindAsync(id);
        if (v is null) return NotFound();
        _db.Vehicles.Remove(v);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}