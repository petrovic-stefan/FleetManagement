using System.Net.Http.Json;

namespace Desktop.Forms;

public partial class ReportsForm : Form
{
    private readonly HttpClient _http = new() { BaseAddress = new Uri("https://localhost:7123/") };

    public ReportsForm()
    {
        InitializeComponent();
        Load += async (_, __) => { await LoadFuelByMonth(); await LoadTopMaintenance(); };
    }

    private async Task LoadFuelByMonth()
    {
        var year = (int)numYear.Value;
        var data = await _http.GetFromJsonAsync<List<FuelByMonthDto>>($"api/reports/fuel-by-month?year={year}");
        gridFuel.DataSource = data;
    }

    private async Task LoadTopMaintenance()
    {
        var top = (int)numTop.Value;
        var data = await _http.GetFromJsonAsync<List<TopMaintenanceDto>>($"api/reports/top-maintenance?top={top}");
        gridTop.DataSource = data;
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await LoadFuelByMonth();
        await LoadTopMaintenance();
    }

    private record FuelByMonthDto(int Year, int Month, decimal Total);
    private record TopMaintenanceDto(int VehicleId, string Plate, int Count);
}