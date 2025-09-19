namespace Domain.Entities;

public class Expense
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public DateTime Date { get; set; }
    public ExpenseCategory Category { get; set; }
    public decimal Amount { get; set; }
    public string? Notes { get; set; }

    public Vehicle? Vehicle { get; set; }
}