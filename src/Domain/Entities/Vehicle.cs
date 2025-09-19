namespace Domain.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public string PlateNumber { get; set; } = string.Empty;
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int? Year { get; set; }
    public string? VIN { get; set; }
    public int Odometer { get; set; }
    public VehicleStatus Status { get; set; } = VehicleStatus.Active;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Maintenance> Maintenance { get; set; } = new List<Maintenance>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}