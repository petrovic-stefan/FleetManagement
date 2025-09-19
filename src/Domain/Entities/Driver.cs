namespace Domain.Entities;

public class Driver
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime? HireDate { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}