using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly FleetDbContext _db;
    public ExpensesController(FleetDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetAll([FromQuery] int? vehicleId, [FromQuery] ExpenseCategory? category)
    {
        var q = _db.Expenses.AsQueryable();
        if (vehicleId.HasValue) q = q.Where(e => e.VehicleId == vehicleId.Value);
        if (category.HasValue) q = q.Where(e => e.Category == category.Value);
        var list = await q.OrderByDescending(e => e.Date).ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Expense>> GetById(int id)
    {
        var e = await _db.Expenses.FindAsync(id);
        return e is null ? NotFound() : Ok(e);
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> Create(Expense e)
    {
        if (!await _db.Vehicles.AnyAsync(v => v.Id == e.VehicleId))
            return BadRequest($"Vehicle {e.VehicleId} not found");

        _db.Expenses.Add(e);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = e.Id }, e);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Expense input)
    {
        if (id != input.Id) return BadRequest();
        _db.Entry(input).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var e = await _db.Expenses.FindAsync(id);
        if (e is null) return NotFound();
        _db.Expenses.Remove(e);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}