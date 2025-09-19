using System.Net.Http.Json;
using System.Linq;
using System.Drawing;
using System.Drawing.Printing;
using Domain.Entities;

namespace Desktop.Forms;

public partial class MaintenanceForm : Form
{
    private readonly HttpClient _http = new() { BaseAddress = new Uri("https://localhost:7123/") };
    private List<Maintenance> _current = new();
    private PrintDocument _printDoc = new();
    private PrintPreviewDialog _preview = new();

    public MaintenanceForm()
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
    var list = await _http.GetFromJsonAsync<List<Maintenance>>("api/maintenance") ?? new();
    var vehicles = await _http.GetFromJsonAsync<List<Vehicle>>("api/vehicles") ?? new();
    var vmap = vehicles.ToDictionary(v => v.Id, v => $"{v.Make} {v.Model} - {v.PlateNumber}");

    var view = list.Select(m => new {
        m.Id,
        Vehicle = vmap.ContainsKey(m.VehicleId) ? vmap[m.VehicleId] : "(unknown)",
        m.Date,
        m.Type,
        m.OdometerAtService,
        CostEUR = string.Format("{0:0.00} €", m.Cost),
        m.Notes,
        m.VehicleId
    }).ToList();

    _current = list;
    grid.AutoGenerateColumns = true;
    grid.DataSource = view;
}
private async void btnPrint_Click(object sender, EventArgs e)
    {
      
        if (cmbVehicle.SelectedValue is int vid)
        {
            _current = await _http.GetFromJsonAsync<List<Maintenance>>($"api/maintenance?vehicleId={vid}") ?? new();
        }
        _preview.Document = _printDoc;
        _preview.Width = 1000; _preview.Height = 800;
        _preview.ShowDialog(this);
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (cmbVehicle.SelectedValue is not int vid) return;
        var m = new Maintenance
        {
            VehicleId = vid,
            Date = dtpDate.Value.Date,
            Type = (MaintenanceType)cmbType.SelectedIndex,
            OdometerAtService = (int)numOdo.Value,
            Cost = numCost.Value,
            Notes = txtNotes.Text
        };
        
    var vehicle = await _http.GetFromJsonAsync<Vehicle>($"api/vehicles/{vid}");
    if (vehicle != null && m.OdometerAtService < vehicle.Odometer)
    {
        MessageBox.Show(
            $"Odometer ne može biti manji od trenutnog stanja vozila ({vehicle.Odometer}).",
            "Validacija",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        );
        return;
    }

    var resp = await _http.PostAsJsonAsync("api/maintenance", m);
if (resp.IsSuccessStatusCode) await RefreshGrid();
}

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        _printDoc.PrintPage += PrintDocOnPrintPage;
    }

    private void PrintDocOnPrintPage(object? sender, PrintPageEventArgs e)
    {
        var g = e.Graphics;
        var font = new Font("Segoe UI", 9);
        float y = 40;
        g.DrawString("Maintenance history", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Black, 40, y - 30);
        foreach (var m in _current.Take(40))
        {
            var line = $"{m.Date:yyyy-MM-dd}  {m.Type}  Odo: {m.OdometerAtService}  Cost: {m.Cost:C}  {m.Notes}";
            g.DrawString(line, font, Brushes.Black, 40, y);
            y += 20;
        }
    }
}