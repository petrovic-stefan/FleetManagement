using System.Net.Http.Json;
using Domain.Entities;
using System.Linq;

namespace Desktop.Forms;

public partial class AssignmentsForm : Form
{
    private readonly HttpClient _http = new() { BaseAddress = new Uri("https://localhost:7123/") };

    public AssignmentsForm()
    {
        InitializeComponent();
        Desktop.EventHub.VehiclesChanged += async () => { try { await LoadVehiclesAndDrivers(); } catch { } };
        Desktop.EventHub.DriversChanged += async () => { try { await LoadVehiclesAndDrivers(); } catch { } };
        Load += async (_, __) => { await LoadVehiclesAndDrivers(); await RefreshGrid(); };
    }

    private async Task LoadVehiclesAndDrivers()
    {
        var vehicles = await _http.GetFromJsonAsync<List<Vehicle>>("api/vehicles") ?? new();
        var vitems = vehicles.Select(v => new { v.Id, Display = $"{v.Make} {v.Model} - {v.PlateNumber}" }).ToList();
        cmbVehicle.DisplayMember = "Display";
        cmbVehicle.ValueMember = "Id";
        cmbVehicle.DataSource = vitems;

        var drivers = await _http.GetFromJsonAsync<List<Driver>>("api/drivers") ?? new();
        var ditems = drivers.Select(d => new { d.Id, Display = d.FullName }).ToList();
        cmbDriver.DisplayMember = "Display";
        cmbDriver.ValueMember = "Id";
        cmbDriver.DataSource = ditems;
    }
    private void chkOpenEnded_CheckedChanged(object? sender, EventArgs e)
    {
        dtpTo.Enabled = !chkOpenEnded.Checked;
    }

    private async Task RefreshGrid()
    {
        var list = await _http.GetFromJsonAsync<List<Assignment>>("api/assignments") ?? new();
        var vehicles = await _http.GetFromJsonAsync<List<Vehicle>>("api/vehicles") ?? new();
        var drivers = await _http.GetFromJsonAsync<List<Driver>>("api/drivers") ?? new();

        var vmap = vehicles.ToDictionary(v => v.Id, v => $"{v.Make} {v.Model} - {v.PlateNumber}");
        var dmap = drivers.ToDictionary(d => d.Id, d => d.FullName);

        var view = list.Select(a => new {
            a.Id,
            Vehicle = vmap.ContainsKey(a.VehicleId) ? vmap[a.VehicleId] : "(unknown)",
            Driver = dmap.ContainsKey(a.DriverId) ? dmap[a.DriverId] : "(unknown)",
            a.FromDate,
            a.ToDate,
            a.Notes,
            a.VehicleId,
            a.DriverId
        }).ToList();

        grid.AutoGenerateColumns = true;
        grid.DataSource = view;

        if (grid.Columns["VehicleId"] != null) grid.Columns["VehicleId"].Visible = false;
        if (grid.Columns["DriverId"] != null) grid.Columns["DriverId"].Visible = false;
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (cmbVehicle.SelectedValue is not int vid) return;
        if (cmbDriver.SelectedValue is not int did) return;

        DateTime? to = chkOpenEnded.Checked ? null : dtpTo.Value.Date;

        var a = new Assignment
        {
            VehicleId = vid,
            DriverId = did,
            FromDate = dtpFrom.Value.Date,
            ToDate = to,
            Notes = txtNotes.Text
        };

        var resp = await _http.PostAsJsonAsync("api/assignments", a);
        if (resp.IsSuccessStatusCode)
        {
            await RefreshGrid();
        }
        else
        {
            var msg = await resp.Content.ReadAsStringAsync();
            MessageBox.Show($"Error: {resp.StatusCode}\n{msg}", "Assignment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
