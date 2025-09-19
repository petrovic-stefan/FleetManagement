namespace Desktop.Forms;

partial class ReportsForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView gridFuel;
    private DataGridView gridTop;
    private NumericUpDown numYear;
    private NumericUpDown numTop;
    private Button btnRefresh;
    private Label lblYear;
    private Label lblTop;
    private Label lblFuelTitle;
    private Label lblTopTitle;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        gridFuel = new DataGridView();
        gridTop = new DataGridView();
        numYear = new NumericUpDown();
        numTop = new NumericUpDown();
        btnRefresh = new Button();
        lblYear = new Label();
        lblTop = new Label();
        lblFuelTitle = new Label();
        lblTopTitle = new Label();
        ((System.ComponentModel.ISupportInitialize)gridFuel).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridTop).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numTop).BeginInit();
        SuspendLayout();
        // 
        // gridFuel
        // 
        gridFuel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        gridFuel.Location = new Point(12, 24);
        gridFuel.Name = "gridFuel";
        gridFuel.ReadOnly = true;
        gridFuel.Size = new Size(1181, 219);
        gridFuel.TabIndex = 0;
        // 
        // gridTop
        // 
        gridTop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        gridTop.Location = new Point(12, 307);
        gridTop.Name = "gridTop";
        gridTop.ReadOnly = true;
        gridTop.Size = new Size(1181, 290);
        gridTop.TabIndex = 1;
        // 
        // numYear
        // 
        numYear.Location = new Point(48, 249);
        numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
        numYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
        numYear.Name = "numYear";
        numYear.Size = new Size(120, 23);
        numYear.TabIndex = 5;
        numYear.Value = new decimal(new int[] { 2025, 0, 0, 0 });
        // 
        // numTop
        // 
        numTop.Location = new Point(202, 249);
        numTop.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
        numTop.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numTop.Name = "numTop";
        numTop.Size = new Size(120, 23);
        numTop.TabIndex = 7;
        numTop.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // btnRefresh
        // 
        btnRefresh.Location = new Point(354, 251);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(96, 21);
        btnRefresh.TabIndex = 8;
        btnRefresh.Text = "Refresh";
        btnRefresh.Click += btnRefresh_Click;
        // 
        // lblYear
        // 
        lblYear.Location = new Point(12, 251);
        lblYear.Name = "lblYear";
        lblYear.Size = new Size(100, 27);
        lblYear.TabIndex = 4;
        lblYear.Text = "Year:";
        // 
        // lblTop
        // 
        lblTop.Location = new Point(174, 251);
        lblTop.Name = "lblTop";
        lblTop.Size = new Size(100, 47);
        lblTop.TabIndex = 6;
        lblTop.Text = "Top:";
        // 
        // lblFuelTitle
        // 
        lblFuelTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblFuelTitle.Location = new Point(12, -2);
        lblFuelTitle.Name = "lblFuelTitle";
        lblFuelTitle.Size = new Size(238, 23);
        lblFuelTitle.TabIndex = 2;
        lblFuelTitle.Text = "Fuel cost by month";
        // 
        // lblTopTitle
        // 
        lblTopTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTopTitle.Location = new Point(12, 281);
        lblTopTitle.Name = "lblTopTitle";
        lblTopTitle.Size = new Size(238, 23);
        lblTopTitle.TabIndex = 3;
        lblTopTitle.Text = "Vehicles with most maintenance";
        // 
        // ReportsForm
        // 
        ClientSize = new Size(1205, 623);
        Controls.Add(numTop);
        Controls.Add(numYear);
        Controls.Add(lblYear);
        Controls.Add(gridFuel);
        Controls.Add(gridTop);
        Controls.Add(lblFuelTitle);
        Controls.Add(lblTopTitle);
        Controls.Add(lblTop);
        Controls.Add(btnRefresh);
        Name = "ReportsForm";
        Text = "Reports";
        ((System.ComponentModel.ISupportInitialize)gridFuel).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridTop).EndInit();
        ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
        ((System.ComponentModel.ISupportInitialize)numTop).EndInit();
        ResumeLayout(false);
    }
}