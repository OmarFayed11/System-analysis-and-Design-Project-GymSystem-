namespace GymSystem.Forms;

partial class frmReviews
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlInput     = new Panel();
        lblMember    = new Label();
        cmbMember    = new ComboBox();
        lblMemberSub = new Label();
        cmbMemberSub = new ComboBox();
        lblScore     = new Label();
        nudScore     = new NumericUpDown();
        lblComment   = new Label();
        txtComment   = new TextBox();
        dgv          = new DataGridView();
        pnlBtn       = new Panel();
        btnSave      = new Button();
        btnDelete    = new Button();
        btnClear     = new Button();

        pnlInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudScore).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        pnlBtn.SuspendLayout();
        SuspendLayout();

        // ── pnlInput ─────────────────────────────────────────────────
        pnlInput.BackColor = Color.WhiteSmoke;
        pnlInput.Dock      = DockStyle.Top;
        pnlInput.Height    = 150;

        lblMember.Text      = "Member:";
        lblMember.Location  = new Point(10, 13);
        lblMember.Size      = new Size(95, 23);
        lblMember.TextAlign = ContentAlignment.MiddleRight;
        cmbMember.Location  = new Point(113, 10);
        cmbMember.Size      = new Size(260, 23);
        cmbMember.DropDownStyle = ComboBoxStyle.DropDownList;

        lblMemberSub.Text      = "Subscription:";
        lblMemberSub.Location  = new Point(10, 48);
        lblMemberSub.Size      = new Size(95, 23);
        lblMemberSub.TextAlign = ContentAlignment.MiddleRight;
        cmbMemberSub.Location  = new Point(113, 45);
        cmbMemberSub.Size      = new Size(260, 23);
        cmbMemberSub.DropDownStyle = ComboBoxStyle.DropDownList;

        lblScore.Text      = "Score (1–5):";
        lblScore.Location  = new Point(10, 83);
        lblScore.Size      = new Size(95, 23);
        lblScore.TextAlign = ContentAlignment.MiddleRight;
        nudScore.Location  = new Point(113, 80);
        nudScore.Size      = new Size(80, 23);
        nudScore.Minimum   = 1;
        nudScore.Maximum   = 5;
        nudScore.Value     = 3;
        nudScore.DecimalPlaces = 1;
        nudScore.Increment = 0.5M;

        lblComment.Text      = "Comment:";
        lblComment.Location  = new Point(10, 118);
        lblComment.Size      = new Size(95, 23);
        lblComment.TextAlign = ContentAlignment.MiddleRight;
        txtComment.Location  = new Point(113, 115);
        txtComment.Size      = new Size(260, 23);

        pnlInput.Controls.AddRange(new Control[]
            { lblMember, cmbMember, lblMemberSub, cmbMemberSub,
              lblScore, nudScore, lblComment, txtComment });

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
        ClientSize          = new Size(720, 500);
        Text                = "Reviews";
        StartPosition       = FormStartPosition.CenterScreen;
        Load               += frmReviews_Load;

        Controls.AddRange(new Control[] { dgv, pnlBtn, pnlInput });

        pnlBtn.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudScore).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        pnlInput.ResumeLayout(false);
        ResumeLayout(false);
    }

    // ── Control fields ────────────────────────────────────────────────
    private Panel         pnlInput     = null!;
    private Panel         pnlBtn       = null!;
    private Label         lblMember    = null!;
    private Label         lblMemberSub = null!;
    private Label         lblScore     = null!;
    private Label         lblComment   = null!;
    private ComboBox      cmbMember    = null!;
    private ComboBox      cmbMemberSub = null!;
    private NumericUpDown nudScore     = null!;
    private TextBox       txtComment   = null!;
    private DataGridView  dgv          = null!;
    private Button        btnSave      = null!;
    private Button        btnDelete    = null!;
    private Button        btnClear     = null!;
}
