namespace Desktop.Forms;

partial class ExpensesForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView grid;
    private ComboBox cmbVehicle;
    private DateTimePicker dtpDate;
    private ComboBox cmbCategory;
    private NumericUpDown numAmount;
    private TextBox txtNotes;
    private Button btnAdd;
    private Label lblVehicle;
    private Label lblDate;
    private Label lblCategory;
    private Label lblAmount;
    private Label lblNotes;

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
        cmbCategory = new ComboBox();
        numAmount = new NumericUpDown();
        txtNotes = new TextBox();
        btnAdd = new Button();
        lblVehicle = new Label();
        lblDate = new Label();
        lblCategory = new Label();
        lblAmount = new Label();
        lblNotes = new Label();
        ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
        SuspendLayout();
        // 
        // grid
        // 
        grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grid.Location = new Point(12, 12);
        grid.Name = "grid";
        grid.ReadOnly = true;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.Size = new Size(1132, 425);
        grid.TabIndex = 0;
        // 
        // cmbVehicle
        // 
        cmbVehicle.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbVehicle.Location = new Point(61, 470);
        cmbVehicle.Name = "cmbVehicle";
        cmbVehicle.Size = new Size(220, 23);
        cmbVehicle.TabIndex = 2;
        // 
        // dtpDate
        // 
        dtpDate.Location = new Point(61, 508);
        dtpDate.Name = "dtpDate";
        dtpDate.Size = new Size(140, 23);
        dtpDate.TabIndex = 4;
        // 
        // cmbCategory
        // 
        cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCategory.Items.AddRange(new object[] { "Fuel", "Toll", "Parking", "Insurance", "Other" });
        cmbCategory.Location = new Point(365, 467);
        cmbCategory.Name = "cmbCategory";
        cmbCategory.Size = new Size(120, 23);
        cmbCategory.TabIndex = 6;
        // 
        // numAmount
        // 
        numAmount.DecimalPlaces = 2;
        numAmount.Location = new Point(391, 512);
        numAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numAmount.Name = "numAmount";
        numAmount.Size = new Size(120, 23);
        numAmount.TabIndex = 8;
        // 
        // txtNotes
        // 
        txtNotes.Location = new Point(608, 464);
        txtNotes.Name = "txtNotes";
        txtNotes.PlaceholderText = "Notes";
        txtNotes.Size = new Size(230, 23);
        txtNotes.TabIndex = 10;
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(570, 514);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(75, 23);
        btnAdd.TabIndex = 11;
        btnAdd.Text = "Add";
        btnAdd.Click += btnAdd_Click;
        // 
        // lblVehicle
        // 
        lblVehicle.BackColor = Color.Transparent;
        lblVehicle.ForeColor = SystemColors.ActiveCaptionText;
        lblVehicle.Location = new Point(12, 473);
        lblVehicle.Name = "lblVehicle";
        lblVehicle.Size = new Size(100, 23);
        lblVehicle.TabIndex = 1;
        lblVehicle.Text = "Vehicle:";
        // 
        // lblDate
        // 
        lblDate.Location = new Point(12, 508);
        lblDate.Name = "lblDate";
        lblDate.Size = new Size(100, 23);
        lblDate.TabIndex = 3;
        lblDate.Text = "Date:";
        // 
        // lblCategory
        // 
        lblCategory.Location = new Point(304, 470);
        lblCategory.Name = "lblCategory";
        lblCategory.Size = new Size(100, 23);
        lblCategory.TabIndex = 5;
        lblCategory.Text = "Category:";
        // 
        // lblAmount
        // 
        lblAmount.Location = new Point(304, 514);
        lblAmount.Name = "lblAmount";
        lblAmount.Size = new Size(100, 23);
        lblAmount.TabIndex = 7;
        lblAmount.Text = "Amount (EUR):";
        // 
        // lblNotes
        // 
        lblNotes.Location = new Point(555, 467);
        lblNotes.Name = "lblNotes";
        lblNotes.Size = new Size(100, 23);
        lblNotes.TabIndex = 9;
        lblNotes.Text = "Notes:";
        // 
        // ExpensesForm
        // 
        ClientSize = new Size(1156, 559);
        Controls.Add(txtNotes);
        Controls.Add(lblNotes);
        Controls.Add(numAmount);
        Controls.Add(cmbCategory);
        Controls.Add(dtpDate);
        Controls.Add(cmbVehicle);
        Controls.Add(grid);
        Controls.Add(lblVehicle);
        Controls.Add(lblDate);
        Controls.Add(lblCategory);
        Controls.Add(lblAmount);
        Controls.Add(btnAdd);
        Name = "ExpensesForm";
        Text = "Expenses";
        ((System.ComponentModel.ISupportInitialize)grid).EndInit();
        ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}