using System.Net.Http.Json;
using System.Linq;
using Domain.Entities;

namespace Desktop.Forms;

public partial class ExpensesForm : Form
{
    private readonly HttpClient _http = new() { BaseAddress = new Uri("https://localhost:7123/") };

    public ExpensesForm()
    {
        InitializeComponent();
        Desktop.EventHub.VehiclesChanged += async () => { try { await LoadVehicles(); } catch { } };
        Load += async (_, __) => { await LoadVehicles(); await RefreshGrid(); };
    }

    private async Task LoadVehicles()
    {
        var vehicles = await _http.GetFromJsonAsync<List<Vehicle>>("api/vehicles") ?? new();
        var items = vehicles.Select(v => new { v.Id, Display = $"{v.Make} {v.Model} - {v.PlateNumber}" }).ToList();
        cmbVehicle.DisplayMember = "Display";
        cmbVehicle.ValueMember = "Id";
        cmbVehicle.DataSource = items;
    }

    private async Task RefreshGrid()
{
    var list = await _http.GetFromJsonAsync<List<Expense>>("api/expenses") ?? new();
    var vehicles = await _http.GetFromJsonAsync<List<Vehicle>>("api/vehicles") ?? new();
    var vmap = vehicles.ToDictionary(v => v.Id, v => $"{v.Make} {v.Model} - {v.PlateNumber}");

    var view = list.Select(e => new {
        e.Id,
        Vehicle = vmap.ContainsKey(e.VehicleId) ? vmap[e.VehicleId] : "(unknown)",
        e.Date,
        e.Category,
        AmountEUR = string.Format("{0:0.00} €", e.Amount),
        e.Notes,
        e.VehicleId
    }).ToList();

    grid.AutoGenerateColumns = true;
    grid.DataSource = view;
}
private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (cmbVehicle.SelectedValue is not int vid) return;
        var e1 = new Expense
        {
            VehicleId = vid,
            Date = dtpDate.Value.Date,
            Category = (ExpenseCategory)cmbCategory.SelectedIndex,
            Amount = numAmount.Value,
            Notes = txtNotes.Text
        };
        var resp = await _http.PostAsJsonAsync("api/expenses", e1);
        if (resp.IsSuccessStatusCode) await RefreshGrid();
    }
}