using System.Net.Http.Json;
using System.Text.Json;
using System.Linq;
using Domain.Entities;

namespace Desktop.Forms;

public partial class MainForm : Form
{
    // 
    private readonly HttpClient _http = new() { BaseAddress = new Uri("https://localhost:7123/") };
    private Desktop.Notifications.NotificationManager? _notify;

    public MainForm()
    {
        InitializeComponent();
        CreateMenu(); 

        // 
        txtPlate.TextChanged += (_, __) => ValidateInputs();
        txtMake.TextChanged += (_, __) => ValidateInputs();
        txtModel.TextChanged += (_, __) => ValidateInputs();
        txtVIN.TextChanged += (_, __) => ValidateInputs();
        btnSearch.Click += async (_, __) => await DoSearch();

        // 
        this.Shown += async (_, __) =>
        {
            _notify = new Desktop.Notifications.NotificationManager(_http);
            _notify.Start();
            await SafeRefreshGrid();
        };

        ValidateInputs();
    }

    private void ValidateInputs()
    {
        bool p = !string.IsNullOrWhiteSpace(txtPlate.Text);
        bool m = !string.IsNullOrWhiteSpace(txtMake.Text);
        bool mo = !string.IsNullOrWhiteSpace(txtModel.Text);
        errorProvider1.SetError(txtPlate, p ? string.Empty : "Plate je obavezno");
        errorProvider1.SetError(txtMake, m ? string.Empty : "Make je obavezno");
        errorProvider1.SetError(txtModel, mo ? string.Empty : "Model je obavezno");
        btnAdd.Enabled = p && m && mo;
    }

    private async Task DoSearch()
    {
        var term = txtSearch.Text?.Trim();
        if (string.IsNullOrWhiteSpace(term))
        {
            await RefreshGrid();
            Desktop.EventHub.RaiseVehiclesChanged();
            return;
        }
        try
        {
            var resp = await _http.GetAsync($"api/vehicles?plate={Uri.EscapeDataString(term)}");
            var raw = await resp.Content.ReadAsStringAsync();
            if (!resp.IsSuccessStatusCode)
            {
                MessageBox.Show($"Search error: {resp.StatusCode}\n{raw}");
                return;
            }
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<List<Vehicle>>(raw, opts) ?? new();
            dataGridView1.DataSource = data;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Search exception: {ex.Message}");
        }
    }

    private async Task SafeRefreshGrid()
    {
        try
        {
            await RefreshGrid();
            Desktop.EventHub.RaiseVehiclesChanged();
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show($"Ne mogu da se povežem na API. Proveri da li radi i port/URL.\n\n{ex.Message}", "API konekcija",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška pri učitavanju: {ex}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task RefreshGrid()
    {
        // 
        var resp = await _http.GetAsync("api/vehicles");
        var raw = await resp.Content.ReadAsStringAsync();
        if (!resp.IsSuccessStatusCode)
        {
            MessageBox.Show(
                $"API nije vratio 200 OK:\nStatus: {resp.StatusCode}\nBody: {raw}",
                "API",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return;
        }

        var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(raw, opts) ?? new List<Vehicle>();

        // 
        var maint = await _http.GetFromJsonAsync<List<Maintenance>>("api/maintenance") ?? new();
        var exps = await _http.GetFromJsonAsync<List<Expense>>("api/expenses") ?? new();
        var assigns = await _http.GetFromJsonAsync<List<Assignment>>("api/assignments") ?? new();

        var mCounts = maint.GroupBy(m => m.VehicleId).ToDictionary(g => g.Key, g => g.Count());
        var eCounts = exps.GroupBy(e => e.VehicleId).ToDictionary(g => g.Key, g => g.Count());
        var aCounts = assigns.GroupBy(a => a.VehicleId).ToDictionary(g => g.Key, g => g.Count());

        var data = vehicles.Select(v => new
        {
            v.Id,
            v.PlateNumber,
            v.Make,
            v.Model,
            v.VIN,
            v.Year,
            v.Odometer,
            MaintenanceCount = mCounts.TryGetValue(v.Id, out var mc) ? mc : 0,
            ExpenseCount = eCounts.TryGetValue(v.Id, out var ec) ? ec : 0,
            AssignmentCount = aCounts.TryGetValue(v.Id, out var ac) ? ac : 0
        }).ToList();

        dataGridView1.AutoGenerateColumns = true;
        dataGridView1.DataSource = data;
        dataGridView1.Refresh();
    }


    private async void btnAdd_Click(object sender, EventArgs e)
    {
        var v = new Vehicle
        {
            PlateNumber = txtPlate.Text,
            Make = txtMake.Text,
            Model = txtModel.Text,
            VIN = txtVIN.Text,
            Year = (int?)numYear.Value,
            Odometer = 0
        };
        var resp = await _http.PostAsJsonAsync("api/vehicles", v);
        if (!resp.IsSuccessStatusCode)
        {
            var body = await resp.Content.ReadAsStringAsync();
            MessageBox.Show($"POST nije uspeo: {resp.StatusCode}\n{body}", "Vehicles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        await RefreshGrid();
        Desktop.EventHub.RaiseVehiclesChanged();
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow?.DataBoundItem is Vehicle v)
        {
            var resp = await _http.DeleteAsync($"api/vehicles/{v.Id}");
            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync();
                MessageBox.Show($"DELETE nije uspeo: {resp.StatusCode}\n{body}", "Vehicles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await RefreshGrid();
            Desktop.EventHub.RaiseVehiclesChanged();
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _notify?.Dispose();
        base.OnFormClosed(e);
    }

    
    private void OpenMaintenance(object? sender, EventArgs e) => new MaintenanceForm().Show();
    private void OpenExpenses(object? sender, EventArgs e) => new ExpensesForm().Show();
    private void OpenDrivers(object? sender, EventArgs e) => new DriversForm().Show();
    private void OpenAssignments(object? sender, EventArgs e) => new AssignmentsForm().Show();
    private void OpenReports(object? sender, EventArgs e) => new ReportsForm().Show();
}