namespace Desktop.Forms;

partial class MaintenanceForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView grid;
    private ComboBox cmbVehicle;
    private DateTimePicker dtpDate;
    private ComboBox cmbType;
    private NumericUpDown numOdo;
    private NumericUpDown numCost;
    private TextBox txtNotes;
    private Button btnAdd;
    private Label lblVehicle;
    private Label lblDate;
    private Label lblType;
    private Label lblOdo;
    private Label lblCost;
    private Label lblNotes;
    private Button btnPrint;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        grid = new DataGridView();
        cmbVehicle = new ComboBox();
        dtpDate = new DateTimePicker();
        cmbType = new ComboBox();
        numOdo = new NumericUpDown();
        numCost = new NumericUpDown();
        txtNotes = new TextBox();
        btnAdd = new Button();
        lblVehicle = new Label();
        lblDate = new Label();
        lblType = new Label();
        lblOdo = new Label();
        lblCost = new Label();
        lblNotes = new Label();
        btnPrint = new Button();
        ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numOdo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
        SuspendLayout();
        // 
        // grid
        // 
        grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grid.Location = new Point(12, 12);
        grid.Name = "grid";
        grid.ReadOnly = true;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.Size = new Size(1058, 466);
        grid.TabIndex = 0;
        // 
        // cmbVehicle
        // 
        cmbVehicle.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbVehicle.Location = new Point(98, 505);
        cmbVehicle.Name = "cmbVehicle";
        cmbVehicle.Size = new Size(220, 23);
        cmbVehicle.TabIndex = 2;
        // 
        // dtpDate
        // 
        dtpDate.Location = new Point(88, 546);
        dtpDate.Name = "dtpDate";
        dtpDate.Size = new Size(140, 23);
        dtpDate.TabIndex = 4;
        // 
        // cmbType
        // 
        cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbType.Items.AddRange(new object[] { "Service", "Repair", "Inspection" });
        cmbType.Location = new Point(387, 505);
        cmbType.Name = "cmbType";
        cmbType.Size = new Size(120, 23);
        cmbType.TabIndex = 6;
        // 
        // numOdo
        // 
        numOdo.Location = new Point(387, 544);
        numOdo.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
        numOdo.Name = "numOdo";
        numOdo.Size = new Size(120, 23);
        numOdo.TabIndex = 8;
        // 
        // numCost
        // 
        numCost.DecimalPlaces = 2;
        numCost.Location = new Point(603, 506);
        numCost.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numCost.Name = "numCost";
        numCost.Size = new Size(120, 23);
        numCost.TabIndex = 10;
        // 
        // txtNotes
        // 
        txtNotes.Location = new Point(583, 543);
        txtNotes.Name = "txtNotes";
        txtNotes.PlaceholderText = "Notes";
        txtNotes.Size = new Size(140, 23);
        txtNotes.TabIndex = 12;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(762, 543);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(75, 23);
        btnAdd.TabIndex = 13;
        btnAdd.Text = "Add";
        btnAdd.Click += btnAdd_Click;
        // 
        // lblVehicle
        // 
        lblVehicle.Location = new Point(50, 505);
        lblVehicle.Name = "lblVehicle";
        lblVehicle.Size = new Size(100, 23);
        lblVehicle.TabIndex = 1;
        lblVehicle.Text = "Vehicle:";
        // 
        // lblDate
        // 
        lblDate.Location = new Point(50, 552);
        lblDate.Name = "lblDate";
        lblDate.Size = new Size(100, 23);
        lblDate.TabIndex = 3;
        lblDate.Text = "Date:";
        // 
        // lblType
        // 
        lblType.Location = new Point(347, 508);
        lblType.Name = "lblType";
        lblType.Size = new Size(100, 23);
        lblType.TabIndex = 5;
        lblType.Text = "Type:";
        // 
        // lblOdo
        // 
        lblOdo.Location = new Point(318, 546);
        lblOdo.Name = "lblOdo";
        lblOdo.Size = new Size(100, 23);
        lblOdo.TabIndex = 7;
        lblOdo.Text = "Odometer:";
        // 
        // lblCost
        // 
        lblCost.Location = new Point(536, 508);
        lblCost.Name = "lblCost";
        lblCost.Size = new Size(100, 23);
        lblCost.TabIndex = 9;
        lblCost.Text = "Cost (EUR):";
        // 
        // lblNotes
        // 
        lblNotes.Location = new Point(536, 544);
        lblNotes.Name = "lblNotes";
        lblNotes.Size = new Size(100, 23);
        lblNotes.TabIndex = 11;
        lblNotes.Text = "Notes:";
        // 
        // btnPrint
        // 
        btnPrint.Location = new Point(762, 504);
        btnPrint.Name = "btnPrint";
        btnPrint.Size = new Size(75, 23);
        btnPrint.TabIndex = 14;
        btnPrint.Text = "Print";
        btnPrint.Click += btnPrint_Click;
        // 
        // MaintenanceForm
        // 
        ClientSize = new Size(1082, 604);
        Controls.Add(txtNotes);
        Controls.Add(numCost);
        Controls.Add(numOdo);
        Controls.Add(cmbType);
        Controls.Add(dtpDate);
        Controls.Add(cmbVehicle);
        Controls.Add(grid);
        Controls.Add(lblVehicle);
        Controls.Add(lblDate);
        Controls.Add(lblType);
        Controls.Add(lblOdo);
        Controls.Add(lblCost);
        Controls.Add(lblNotes);
        Controls.Add(btnAdd);
        Controls.Add(btnPrint);
        Name = "MaintenanceForm";
        Text = "Maintenance";
        ((System.ComponentModel.ISupportInitialize)grid).EndInit();
        ((System.ComponentModel.ISupportInitialize)numOdo).EndInit();
        ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}