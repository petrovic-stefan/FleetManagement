namespace Domain.Entities;

public class Maintenance
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public DateTime Date { get; set; }
    public MaintenanceType Type { get; set; }
    public int OdometerAtService { get; set; }
    public decimal Cost { get; set; }
    public string? Notes { get; set; }

    public Vehicle? Vehicle { get; set; }
}