using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaintenanceController : ControllerBase
{
    private readonly FleetDbContext _db;
    public MaintenanceController(FleetDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Maintenance>>> GetAll([FromQuery] int? vehicleId)
    {
        var q = _db.Maintenance.AsQueryable();
        if (vehicleId.HasValue) q = q.Where(m => m.VehicleId == vehicleId.Value);
        var list = await q.OrderByDescending(m => m.Date).ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Maintenance>> GetById(int id)
    {
        var m = await _db.Maintenance.FindAsync(id);
        return m is null ? NotFound() : Ok(m);
    }

    [HttpPost]
    public async Task<ActionResult<Maintenance>> Create(Maintenance m)
    {
        if (!await _db.Vehicles.AnyAsync(v => v.Id == m.VehicleId))
            return BadRequest($"Vehicle {m.VehicleId} not found");

        _db.Maintenance.Add(m);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = m.Id }, m);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Maintenance input)
    {
        if (id != input.Id) return BadRequest();
        _db.Entry(input).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var m = await _db.Maintenance.FindAsync(id);
        if (m is null) return NotFound();
        _db.Maintenance.Remove(m);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}