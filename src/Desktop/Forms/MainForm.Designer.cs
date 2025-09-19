using System.Drawing;
using System.Windows.Forms;

namespace Desktop.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dataGridView1;
    private TextBox txtPlate;
    private TextBox txtMake;
    private TextBox txtModel;
    private TextBox txtVIN;
    private NumericUpDown numYear;
    private Button btnAdd;
    private Button btnDelete;
    private TextBox txtSearch;
    private Button btnSearch;
    private ErrorProvider errorProvider1;
    private ToolTip toolTip1;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        dataGridView1 = new DataGridView();
        txtPlate = new TextBox();
        txtMake = new TextBox();
        txtModel = new TextBox();
        txtVIN = new TextBox();
        numYear = new NumericUpDown();
        btnAdd = new Button();
        btnDelete = new Button();
        txtSearch = new TextBox();
        btnSearch = new Button();
        errorProvider1 = new ErrorProvider(components);
        toolTip1 = new ToolTip(components);
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.Location = new Point(12, 60);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.Size = new Size(763, 306);
        dataGridView1.TabIndex = 0;
        // 
        // txtPlate
        // 
        txtPlate.Location = new Point(12, 380);
        txtPlate.Name = "txtPlate";
        txtPlate.PlaceholderText = "Plate";
        txtPlate.Size = new Size(120, 23);
        txtPlate.TabIndex = 1;
        toolTip1.SetToolTip(txtPlate, "Obavezno: npr. BG-123-AB");
        // 
        // txtMake
        // 
        txtMake.Location = new Point(136, 380);
        txtMake.Name = "txtMake";
        txtMake.PlaceholderText = "Make";
        txtMake.Size = new Size(120, 23);
        txtMake.TabIndex = 2;
        toolTip1.SetToolTip(txtMake, "Marka, npr. Ford");
        // 
        // txtModel
        // 
        txtModel.Location = new Point(260, 380);
        txtModel.Name = "txtModel";
        txtModel.PlaceholderText = "Model";
        txtModel.Size = new Size(120, 23);
        txtModel.TabIndex = 3;
        toolTip1.SetToolTip(txtModel, "Model, npr. Transit");
        // 
        // txtVIN
        // 
        txtVIN.Location = new Point(384, 380);
        txtVIN.Name = "txtVIN";
        txtVIN.PlaceholderText = "VIN";
        txtVIN.Size = new Size(120, 23);
        txtVIN.TabIndex = 4;
        toolTip1.SetToolTip(txtVIN, "VIN (opciono)");
        // 
        // numYear
        // 
        numYear.Location = new Point(508, 380);
        numYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
        numYear.Minimum = new decimal(new int[] { 1980, 0, 0, 0 });
        numYear.Name = "numYear";
        numYear.Size = new Size(80, 23);
        numYear.TabIndex = 5;
        numYear.Value = new decimal(new int[] { 2018, 0, 0, 0 });
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(600, 378);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(75, 23);
        btnAdd.TabIndex = 6;
        btnAdd.Text = "Add";
        // 
        // btnDelete
        // 
        btnDelete.Location = new Point(680, 378);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(75, 23);
        btnDelete.TabIndex = 7;
        btnDelete.Text = "Delete";
        // 
        // txtSearch
        // 
        txtSearch.Location = new Point(550, 33);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Search plate/make";
        txtSearch.Size = new Size(140, 23);
        txtSearch.TabIndex = 8;
        // 
        // btnSearch
        // 
        btnSearch.Location = new Point(700, 31);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(75, 23);
        btnSearch.TabIndex = 9;
        btnSearch.Text = "Search";
        // 
        // errorProvider1
        // 
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider1.ContainerControl = this;
        // 
        // MainForm
        // 
        ClientSize = new Size(784, 421);
        Controls.Add(dataGridView1);
        Controls.Add(txtPlate);
        Controls.Add(txtMake);
        Controls.Add(txtModel);
        Controls.Add(txtVIN);
        Controls.Add(numYear);
        Controls.Add(btnAdd);
        Controls.Add(btnDelete);
        Controls.Add(txtSearch);
        Controls.Add(btnSearch);
        Name = "MainForm";
        Text = "Fleet Management";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}