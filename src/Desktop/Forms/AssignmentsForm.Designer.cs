using System.Drawing;
using System.Windows.Forms;

namespace Desktop.Forms;

partial class AssignmentsForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView grid;
    private ComboBox cmbVehicle;
    private ComboBox cmbDriver;
    private DateTimePicker dtpFrom;
    private DateTimePicker dtpTo;
    private CheckBox chkOpenEnded;
    private TextBox txtNotes;
    private Button btnAdd;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.grid = new DataGridView();
        this.cmbVehicle = new ComboBox();
        this.cmbDriver = new ComboBox();
        this.dtpFrom = new DateTimePicker();
        this.dtpTo = new DateTimePicker();
        this.chkOpenEnded = new CheckBox();
        this.txtNotes = new TextBox();
        this.btnAdd = new Button();

        this.SuspendLayout();

        // grid
        this.grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.grid.Location = new Point(12, 12);
        this.grid.Size = new Size(760, 300);
        this.grid.ReadOnly = true;
        this.grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.grid.MultiSelect = false;
        this.grid.RowHeadersVisible = false;
        this.grid.AllowUserToAddRows = false;
        this.grid.AllowUserToDeleteRows = false;
        this.grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // cmbVehicle
        this.cmbVehicle.Location = new Point(12, 320);
        this.cmbVehicle.Width = 220;
        this.cmbVehicle.DropDownStyle = ComboBoxStyle.DropDownList;

        // cmbDriver
        this.cmbDriver.Location = new Point(238, 320);
        this.cmbDriver.Width = 180;
        this.cmbDriver.DropDownStyle = ComboBoxStyle.DropDownList;

        // dtpFrom
        this.dtpFrom.Location = new Point(430, 320);
        this.dtpFrom.Width = 160;

        // dtpTo
        this.dtpTo.Location = new Point(596, 320);
        this.dtpTo.Width = 160;

        // chkOpenEnded
        this.chkOpenEnded.Location = new Point(12, 350);
        this.chkOpenEnded.Text = "Open-ended";
        this.chkOpenEnded.Checked = false;
        this.chkOpenEnded.CheckedChanged += new System.EventHandler(this.chkOpenEnded_CheckedChanged);

        // txtNotes
        this.txtNotes.Location = new Point(12, 380);
        this.txtNotes.Width = 600;

        // btnAdd
        this.btnAdd.Location = new Point(700, 378);
        this.btnAdd.Text = "Add";
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        // Form
        this.ClientSize = new Size(784, 411);
        this.Controls.AddRange(new Control[] { this.grid, this.cmbVehicle, this.cmbDriver, this.dtpFrom, this.dtpTo, this.chkOpenEnded, this.txtNotes, this.btnAdd });
        this.Name = "AssignmentsForm";
        this.Text = "Assignments";

        this.ResumeLayout(false);
    }
}
