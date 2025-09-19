using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly FleetDbContext _db;
    public ReportsController(FleetDbContext db) => _db = db;

    // GET api/reports/fuel-by-month?year=2025
    [HttpGet("fuel-by-month")]
    public async Task<ActionResult<IEnumerable<object>>> FuelByMonth([FromQuery] int? year)
    {
        var q = _db.Expenses.Where(e => e.Category == Domain.Entities.ExpenseCategory.Fuel);
        if (year.HasValue) q = q.Where(e => e.Date.Year == year.Value);

        var data = await q
            .GroupBy(e => new { e.Date.Year, e.Date.Month })
            .Select(g => new { Year = g.Key.Year, Month = g.Key.Month, Total = g.Sum(x => x.Amount) })
            .OrderBy(x => x.Year).ThenBy(x => x.Month)
            .ToListAsync();

        return Ok(data);
    }

    // GET api/reports/top-maintenance?top=5
    [HttpGet("top-maintenance")]
    public async Task<ActionResult<IEnumerable<object>>> TopMaintenance([FromQuery] int top = 5)
    {
        var data = await _db.Maintenance
            .GroupBy(m => m.VehicleId)
            .Select(g => new { VehicleId = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(top)
            .ToListAsync();

        // 
        var vehiclePlates = await _db.Vehicles
            .Where(v => data.Select(d => d.VehicleId).Contains(v.Id))
            .Select(v => new { v.Id, v.PlateNumber })
            .ToDictionaryAsync(x => x.Id, x => x.PlateNumber);

        var result = data.Select(d => new { d.VehicleId, Plate = vehiclePlates.GetValueOrDefault(d.VehicleId, "?"), d.Count });
        return Ok(result);
    }
}