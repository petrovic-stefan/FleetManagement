using System.Windows.Forms;
using System.Drawing;

namespace Desktop.Forms;

public partial class MainForm
{
    private MenuStrip _menuStrip;
    private ToolStripMenuItem _miVehicles;
    private ToolStripMenuItem _miMaintenance;
    private ToolStripMenuItem _miExpenses;
    private ToolStripMenuItem _miDrivers;
    private ToolStripMenuItem _miAssignments;
    private ToolStripMenuItem _miReports;

    private void CreateMenu()
    {
        _menuStrip = new MenuStrip();
        _miVehicles = new ToolStripMenuItem("&Vehicles");
        _miMaintenance = new ToolStripMenuItem("&Maintenance");
        _miExpenses = new ToolStripMenuItem("&Expenses");
        _miDrivers = new ToolStripMenuItem("&Drivers");
        _miAssignments = new ToolStripMenuItem("&Assignments");
        _miReports = new ToolStripMenuItem("&Reports");

        _miMaintenance.Click += OpenMaintenance;
        _miExpenses.Click += OpenExpenses;
        _miDrivers.Click += OpenDrivers;
        _miAssignments.Click += OpenAssignments;
        _miReports.Click += OpenReports;

        _menuStrip.Items.AddRange(new ToolStripItem[] {
            _miVehicles, _miMaintenance, _miExpenses, _miDrivers, _miAssignments, _miReports
        });
        _menuStrip.Dock = DockStyle.Top;
        this.MainMenuStrip = _menuStrip;
        this.Controls.Add(_menuStrip);

        
        int h = _menuStrip.Height;
        foreach (Control c in this.Controls)
        {
            if (c == _menuStrip) continue;
            if (c.Top < h) c.Top = h + 8;
        }
    }
}