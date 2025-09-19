using System.Net.Http.Json;
using Domain.Entities;
using System.Linq;

namespace Desktop.Forms;

public partial class DriversForm : Form
{
    private readonly HttpClient _http = new() { BaseAddress = new Uri("https://localhost:7123/") };

    public DriversForm()
    {
        InitializeComponent();
        Load += async (_, __) => await RefreshGrid();
    }

    private async Task RefreshGrid()
{
    var drivers = await _http.GetFromJsonAsync<List<Driver>>("api/drivers") ?? new();
    var assigns = await _http.GetFromJsonAsync<List<Assignment>>("api/assignments") ?? new();
    var aCounts = assigns.GroupBy(a => a.DriverId).ToDictionary(g => g.Key, g => g.Count());

    var view = drivers.Select(d => new {
        d.Id,
        d.FullName,
        d.Phone,
        Assignments = aCounts.TryGetValue(d.Id, out var c) ? c : 0
    }).ToList();

    grid.AutoGenerateColumns = true;
    grid.DataSource = view;
}
private async void btnAdd_Click(object sender, EventArgs e)
    {
        var d = new Driver
        {
            FullName = txtName.Text,
            LicenseNumber = txtLicense.Text,
            Phone = txtPhone.Text,
            Email = txtEmail.Text,
            HireDate = dtpHire.Value.Date,
            IsActive = chkActive.Checked
        };
        var resp = await _http.PostAsJsonAsync("api/drivers", d);
        if (resp.IsSuccessStatusCode) { await RefreshGrid(); Desktop.EventHub.RaiseDriversChanged(); }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (grid.CurrentRow?.DataBoundItem is Driver d)
        {
            var resp = await _http.DeleteAsync($"api/drivers/{d.Id}");
            if (resp.IsSuccessStatusCode) { await RefreshGrid(); Desktop.EventHub.RaiseDriversChanged(); }
        }
    }
}