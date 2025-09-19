using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentsController : ControllerBase
{
    private readonly FleetDbContext _db;
    public AssignmentsController(FleetDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Assignment>>> Get([FromQuery] int? vehicleId, [FromQuery] int? driverId)
    {
        var q = _db.Assignments.AsQueryable();
        if (vehicleId.HasValue) q = q.Where(a => a.VehicleId == vehicleId.Value);
        if (driverId.HasValue) q = q.Where(a => a.DriverId == driverId.Value);
        var list = await q.OrderByDescending(a => a.FromDate).ToListAsync();
        return Ok(list);
    }

    [HttpPost]
    public async Task<ActionResult<Assignment>> Create(Assignment a)
    {
        if (!await _db.Vehicles.AnyAsync(v => v.Id == a.VehicleId))
            return BadRequest($"Vehicle {a.VehicleId} not found");
        if (!await _db.Drivers.AnyAsync(d => d.Id == a.DriverId))
            return BadRequest($"Driver {a.DriverId} not found");

        //
        var newFrom = a.FromDate.Date;
        var newTo = a.ToDate?.Date;

        bool overlaps = await _db.Assignments.AnyAsync(x =>
            x.Id != a.Id &&
            (
                x.VehicleId == a.VehicleId || x.DriverId == a.DriverId
            ) &&
            // 
            (newFrom <= (x.ToDate ?? DateTime.MaxValue).Date) &&
            ((newTo ?? DateTime.MaxValue.Date) >= x.FromDate.Date)
        );

        if (overlaps)
            return Conflict("Assignment overlaps with an existing assignment for this vehicle or driver.");

        _db.Assignments.Add(a);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = a.Id }, a);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Assignment>> GetById(int id)
    {
        var a = await _db.Assignments.FindAsync(id);
        return a is null ? NotFound() : Ok(a);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Assignment input)
    {
        if (id != input.Id) return BadRequest();

        // 
        var newFrom = input.FromDate.Date;
        var newTo = input.ToDate?.Date;

        bool overlaps = await _db.Assignments.AnyAsync(x =>
            x.Id != input.Id &&
            (x.VehicleId == input.VehicleId || x.DriverId == input.DriverId) &&
            (newFrom <= (x.ToDate ?? DateTime.MaxValue).Date) &&
            ((newTo ?? DateTime.MaxValue.Date) >= x.FromDate.Date)
        );

        if (overlaps)
            return Conflict("Assignment overlaps with an existing assignment for this vehicle or driver.");

        _db.Entry(input).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var a = await _db.Assignments.FindAsync(id);
        if (a is null) return NotFound();
        _db.Assignments.Remove(a);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}