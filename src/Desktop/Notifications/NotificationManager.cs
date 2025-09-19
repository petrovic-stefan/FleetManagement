using System.Linq;
using System.Net.Http.Json;
using System.Timers;
using System.Windows.Forms;
using Domain.Entities;

namespace Desktop.Notifications;

public class NotificationManager : IDisposable
{
    private readonly HttpClient _http;
    private readonly NotifyIcon _tray;
    private readonly System.Timers.Timer _timer;

    public NotificationManager(HttpClient http)
    {
        _http = http;
        _tray = new NotifyIcon { Visible = true, Icon = System.Drawing.SystemIcons.Information, Text = "Fleet Notifications" };
        _timer = new System.Timers.Timer(60_000); // check every 1 min
        _timer.Elapsed += async (_, __) => await CheckDueMaintenance();
    }

    public void Start()
    {
        _timer.Start();
    }

    public void Stop()
    {
        _timer.Stop();
    }

    private async Task CheckDueMaintenance()
    {
        try
        {
            var vehicles = await _http.GetFromJsonAsync<List<Vehicle>>("api/vehicles") ?? new();
            var maint = await _http.GetFromJsonAsync<List<Maintenance>>("api/maintenance") ?? new();

            var byVehicle = maint.GroupBy(m => m.VehicleId).ToDictionary(g => g.Key, g => g.OrderByDescending(x => x.Date).FirstOrDefault());

            var dueList = new List<string>();
            foreach (var v in vehicles)
            {
                if (!byVehicle.TryGetValue(v.Id, out var last) || last is null) continue;
                var days = (DateTime.UtcNow.Date - last.Date.Date).TotalDays;
                var kmSince = v.Odometer - last.OdometerAtService;

                if (days >= 365 || kmSince >= 15000)
                {
                    dueList.Add($"{v.Make} {v.Model} - {v.PlateNumber} (due: {(days>=365 ? "time" : "")}{(days>=365 && kmSince>=15000 ? " & " : "")}{(kmSince>=15000 ? "mileage" : "")})");
                }
            }

            if (dueList.Count > 0)
            {
                var msg = string.Join("\n", dueList.Take(5));
                _tray.BalloonTipTitle = "Maintenance due";
                _tray.BalloonTipText = msg + (dueList.Count > 5 ? $"\n(+{dueList.Count - 5} more)" : "");
                _tray.ShowBalloonTip(5000);
            }
        }
        catch
        {
            // swallow – no UI noise
        }
    }

    public void Dispose()
    {
        _timer.Stop();
        _timer.Dispose();
        _tray.Visible = false;
        _tray.Dispose();
    }
}