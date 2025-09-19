using System.Windows.Forms;

namespace Desktop.Ui;

public static class UiStyling
{
    public static void ApplyGridStyle(DataGridView grid)
    {
        grid.AutoGenerateColumns = true;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;
        grid.ReadOnly = true;
        grid.RowHeadersVisible = false;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
        grid.DefaultCellStyle.Padding = new Padding(4);
        grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 234, 247);
        grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
        grid.BorderStyle = BorderStyle.None;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        grid.ColumnHeadersHeight = 30;
        grid.RowTemplate.Height = 28;
        grid.DoubleBuffered(true);
    }

    
    private static void DoubleBuffered(this DataGridView dgv, bool setting)
    {
        var dgvType = dgv.GetType();
        var pi = dgvType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        pi?.SetValue(dgv, setting, null);
    }
}