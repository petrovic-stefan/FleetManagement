namespace Domain.Entities;

public class Assignment
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public int DriverId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string? Notes { get; set; }

    public Vehicle? Vehicle { get; set; }
    public Driver? Driver { get; set; }
}