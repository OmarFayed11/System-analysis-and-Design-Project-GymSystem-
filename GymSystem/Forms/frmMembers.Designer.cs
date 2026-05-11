namespace GymSystem.Forms;

partial class frmMembers
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
        lblEmail    = new Label();
        txtEmail    = new TextBox();
        lblJoin     = new Label();
        dtpJoin     = new DateTimePicker();
        lblTrainer  = new Label();
        cmbTrainer  = new ComboBox();
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
        pnlInput.Height    = 185;

        lblName.Text      = "Name:";
        lblName.Location  = new Point(10, 13);
        lblName.Size      = new Size(90, 23);
        lblName.TextAlign = ContentAlignment.MiddleRight;
        txtName.Location  = new Point(108, 10);
        txtName.Size      = new Size(240, 23);

        lblPhone.Text      = "Phone:";
        lblPhone.Location  = new Point(10, 48);
        lblPhone.Size      = new Size(90, 23);
        lblPhone.TextAlign = ContentAlignment.MiddleRight;
        txtPhone.Location  = new Point(108, 45);
        txtPhone.Size      = new Size(240, 23);

        lblEmail.Text      = "Email:";
        lblEmail.Location  = new Point(10, 83);
        lblEmail.Size      = new Size(90, 23);
        lblEmail.TextAlign = ContentAlignment.MiddleRight;
        txtEmail.Location  = new Point(108, 80);
        txtEmail.Size      = new Size(240, 23);

        lblJoin.Text      = "Join Date:";
        lblJoin.Location  = new Point(10, 118);
        lblJoin.Size      = new Size(90, 23);
        lblJoin.TextAlign = ContentAlignment.MiddleRight;
        dtpJoin.Location  = new Point(108, 115);
        dtpJoin.Size      = new Size(180, 23);
        dtpJoin.Format    = DateTimePickerFormat.Short;

        lblTrainer.Text      = "Trainer:";
        lblTrainer.Location  = new Point(10, 153);
        lblTrainer.Size      = new Size(90, 23);
        lblTrainer.TextAlign = ContentAlignment.MiddleRight;
        cmbTrainer.Location  = new Point(108, 150);
        cmbTrainer.Size      = new Size(240, 23);
        cmbTrainer.DropDownStyle = ComboBoxStyle.DropDownList;

        pnlInput.Controls.AddRange(new Control[]
            { lblName, txtName, lblPhone, txtPhone, lblEmail, txtEmail,
              lblJoin, dtpJoin, lblTrainer, cmbTrainer });

        // ── dgv ──────────────────────────────────────────────────────
        dgv.Dock                = DockStyle.Fill;
        dgv.ReadOnly            = true;
        dgv.AllowUserToAddRows  = false;
        dgv.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect         = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.SelectionChanged   += dgv_SelectionChanged;

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
        ClientSize          = new Size(680, 520);
        Text                = "Members";
        StartPosition       = FormStartPosition.CenterScreen;
        Load               += frmMembers_Load;

        Controls.AddRange(new Control[] { dgv, pnlBtn, pnlInput });

        pnlBtn.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        pnlInput.ResumeLayout(false);
        ResumeLayout(false);
    }

    // ── Control fields ────────────────────────────────────────────────
    private Panel        pnlInput   = null!;
    private Panel        pnlBtn     = null!;
    private Label        lblName    = null!;
    private Label        lblPhone   = null!;
    private Label        lblEmail   = null!;
    private Label        lblJoin    = null!;
    private Label        lblTrainer = null!;
    private TextBox      txtName    = null!;
    private TextBox      txtPhone   = null!;
    private TextBox      txtEmail   = null!;
    private DateTimePicker dtpJoin  = null!;
    private ComboBox     cmbTrainer = null!;
    private DataGridView dgv        = null!;
    private Button       btnSave    = null!;
    private Button       btnDelete  = null!;
    private Button       btnClear   = null!;
}
