namespace Desktop.Forms;

partial class DriversForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView grid;
    private TextBox txtName;
    private TextBox txtLicense;
    private TextBox txtPhone;
    private TextBox txtEmail;
    private DateTimePicker dtpHire;
    private CheckBox chkActive;
    private Button btnAdd;
    private Button btnDelete;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        grid = new DataGridView();
        txtName = new TextBox();
        txtLicense = new TextBox();
        txtPhone = new TextBox();
        txtEmail = new TextBox();
        dtpHire = new DateTimePicker();
        chkActive = new CheckBox();
        btnAdd = new Button();
        btnDelete = new Button();

        SuspendLayout();

        grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        grid.Location = new Point(12, 12);
        grid.Size = new Size(760, 300);
        grid.ReadOnly = true;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        txtName.Location = new Point(12, 320);
        txtName.Width = 160;
        txtName.PlaceholderText = "Full name";

        txtLicense.Location = new Point(178, 320);
        txtLicense.Width = 120;
        txtLicense.PlaceholderText = "License";

        txtPhone.Location = new Point(304, 320);
        txtPhone.Width = 120;
        txtPhone.PlaceholderText = "Phone";

        txtEmail.Location = new Point(430, 320);
        txtEmail.Width = 160;
        txtEmail.PlaceholderText = "Email";

        dtpHire.Location = new Point(12, 350);
        dtpHire.Width = 160;

        chkActive.Location = new Point(178, 352);
        chkActive.Text = "Active";
        chkActive.Checked = true;

        btnAdd.Location = new Point(700, 318);
        btnAdd.Text = "Add";
        btnAdd.Click += btnAdd_Click;

        btnDelete.Location = new Point(700, 348);
        btnDelete.Text = "Delete";
        btnDelete.Click += btnDelete_Click;

        ClientSize = new Size(784, 381);
        Controls.AddRange(new Control[] { grid, txtName, txtLicense, txtPhone, txtEmail, dtpHire, chkActive, btnAdd, btnDelete });
        Text = "Drivers";
        Desktop.Ui.UiStyling.ApplyGridStyle(grid);
        ResumeLayout(false);
    }
}