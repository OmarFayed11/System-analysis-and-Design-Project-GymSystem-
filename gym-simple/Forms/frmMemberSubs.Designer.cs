namespace GymSystem.Forms;

partial class frmMemberSubs
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlInput  = new Panel();
        lblMember = new Label();
        cmbMember = new ComboBox();
        lblSub    = new Label();
        cmbSub    = new ComboBox();
        lblStart  = new Label();
        dtpStart  = new DateTimePicker();
        lblEnd    = new Label();
        dtpEnd    = new DateTimePicker();
        dgv       = new DataGridView();
        pnlBtn    = new Panel();
        btnSave   = new Button();
        btnDelete = new Button();
        btnClear  = new Button();

        pnlInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        pnlBtn.SuspendLayout();
        SuspendLayout();

        // ── pnlInput ─────────────────────────────────────────────────
        pnlInput.BackColor = Color.WhiteSmoke;
        pnlInput.Dock      = DockStyle.Top;
        pnlInput.Height    = 150;

        lblMember.Text      = "Member:";
        lblMember.Location  = new Point(10, 13);
        lblMember.Size      = new Size(90, 23);
        lblMember.TextAlign = ContentAlignment.MiddleRight;
        cmbMember.Location  = new Point(108, 10);
        cmbMember.Size      = new Size(260, 23);
        cmbMember.DropDownStyle = ComboBoxStyle.DropDownList;

        lblSub.Text      = "Plan:";
        lblSub.Location  = new Point(10, 48);
        lblSub.Size      = new Size(90, 23);
        lblSub.TextAlign = ContentAlignment.MiddleRight;
        cmbSub.Location  = new Point(108, 45);
        cmbSub.Size      = new Size(260, 23);
        cmbSub.DropDownStyle = ComboBoxStyle.DropDownList;

        lblStart.Text      = "Start Date:";
        lblStart.Location  = new Point(10, 83);
        lblStart.Size      = new Size(90, 23);
        lblStart.TextAlign = ContentAlignment.MiddleRight;
        dtpStart.Location  = new Point(108, 80);
        dtpStart.Size      = new Size(160, 23);
        dtpStart.Format    = DateTimePickerFormat.Short;

        lblEnd.Text      = "End Date:";
        lblEnd.Location  = new Point(10, 118);
        lblEnd.Size      = new Size(90, 23);
        lblEnd.TextAlign = ContentAlignment.MiddleRight;
        dtpEnd.Location  = new Point(108, 115);
        dtpEnd.Size      = new Size(160, 23);
        dtpEnd.Format    = DateTimePickerFormat.Short;
        dtpEnd.Value     = DateTime.Today.AddMonths(1);

        pnlInput.Controls.AddRange(new Control[]
            { lblMember, cmbMember, lblSub, cmbSub,
              lblStart, dtpStart, lblEnd, dtpEnd });

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
        ClientSize          = new Size(700, 500);
        Text                = "Member Subscriptions";
        StartPosition       = FormStartPosition.CenterScreen;
        Load               += frmMemberSubs_Load;

        Controls.AddRange(new Control[] { dgv, pnlBtn, pnlInput });

        pnlBtn.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        pnlInput.ResumeLayout(false);
        ResumeLayout(false);
    }

    // ── Control fields ────────────────────────────────────────────────
    private Panel          pnlInput  = null!;
    private Panel          pnlBtn    = null!;
    private Label          lblMember = null!;
    private Label          lblSub    = null!;
    private Label          lblStart  = null!;
    private Label          lblEnd    = null!;
    private ComboBox       cmbMember = null!;
    private ComboBox       cmbSub    = null!;
    private DateTimePicker dtpStart  = null!;
    private DateTimePicker dtpEnd    = null!;
    private DataGridView   dgv       = null!;
    private Button         btnSave   = null!;
    private Button         btnDelete = null!;
    private Button         btnClear  = null!;
}
