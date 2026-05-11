namespace GymSystem.Forms;

partial class frmTrainers
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlInput    = new Panel();
        lblName     = new Label();
        txtName     = new TextBox();
        lblPhone    = new Label();
        txtPhone    = new TextBox();
        lblSpecialty = new Label();
        txtSpecialty = new TextBox();
        dgv         = new DataGridView();
        pnlBtn      = new Panel();
        btnSave     = new Button();
        btnDelete   = new Button();
        btnClear    = new Button();

        pnlInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        pnlBtn.SuspendLayout();
        SuspendLayout();

        // ── pnlInput ─────────────────────────────────────────────────
        pnlInput.BackColor = Color.WhiteSmoke;
        pnlInput.Dock      = DockStyle.Top;
        pnlInput.Height    = 115;

        lblName.Text      = "Name:";
        lblName.Location  = new Point(10, 13);
        lblName.Size      = new Size(90, 23);
        lblName.TextAlign = ContentAlignment.MiddleRight;

        txtName.Location = new Point(108, 10);
        txtName.Size     = new Size(240, 23);

        lblPhone.Text      = "Phone:";
        lblPhone.Location  = new Point(10, 48);
        lblPhone.Size      = new Size(90, 23);
        lblPhone.TextAlign = ContentAlignment.MiddleRight;

        txtPhone.Location = new Point(108, 45);
        txtPhone.Size     = new Size(240, 23);

        lblSpecialty.Text      = "Specialty:";
        lblSpecialty.Location  = new Point(10, 83);
        lblSpecialty.Size      = new Size(90, 23);
        lblSpecialty.TextAlign = ContentAlignment.MiddleRight;

        txtSpecialty.Location = new Point(108, 80);
        txtSpecialty.Size     = new Size(240, 23);

        pnlInput.Controls.AddRange(new Control[]
            { lblName, txtName, lblPhone, txtPhone, lblSpecialty, txtSpecialty });

        // ── dgv ──────────────────────────────────────────────────────
        dgv.Dock                  = DockStyle.Fill;
        dgv.ReadOnly              = true;
        dgv.AllowUserToAddRows    = false;
        dgv.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect           = false;
        dgv.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.SelectionChanged     += dgv_SelectionChanged;

        // ── pnlBtn ───────────────────────────────────────────────────
        pnlBtn.BackColor = Color.WhiteSmoke;
        pnlBtn.Dock      = DockStyle.Bottom;
        pnlBtn.Height    = 45;

        btnSave.Text      = "Save";
        btnSave.Location  = new Point(10, 7);
        btnSave.Size      = new Size(85, 30);
        btnSave.Click    += btnSave_Click;

        btnDelete.Text     = "Delete";
        btnDelete.Location = new Point(105, 7);
        btnDelete.Size     = new Size(85, 30);
        btnDelete.Click   += btnDelete_Click;

        btnClear.Text     = "Clear";
        btnClear.Location = new Point(200, 7);
        btnClear.Size     = new Size(85, 30);
        btnClear.Click   += btnClear_Click;

        pnlBtn.Controls.AddRange(new Control[] { btnSave, btnDelete, btnClear });

        // ── Form ─────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode       = AutoScaleMode.Font;
        ClientSize          = new Size(680, 480);
        Text                = "Trainers";
        StartPosition       = FormStartPosition.CenterScreen;
        Load               += frmTrainers_Load;

        Controls.AddRange(new Control[] { dgv, pnlBtn, pnlInput });

        pnlBtn.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        pnlInput.ResumeLayout(false);
        ResumeLayout(false);
    }

    // ── Control fields ────────────────────────────────────────────────
    private Panel       pnlInput    = null!;
    private Panel       pnlBtn      = null!;
    private Label       lblName     = null!;
    private Label       lblPhone    = null!;
    private Label       lblSpecialty = null!;
    private TextBox     txtName     = null!;
    private TextBox     txtPhone    = null!;
    private TextBox     txtSpecialty = null!;
    private DataGridView dgv        = null!;
    private Button      btnSave     = null!;
    private Button      btnDelete   = null!;
    private Button      btnClear    = null!;
}
