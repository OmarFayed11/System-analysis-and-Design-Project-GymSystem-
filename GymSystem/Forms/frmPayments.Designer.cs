namespace GymSystem.Forms;

partial class frmPayments
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
        lblMemberSub = new Label();
        cmbMemberSub = new ComboBox();
        lblAmount    = new Label();
        nudAmount    = new NumericUpDown();
        lblDate      = new Label();
        dtpDate      = new DateTimePicker();
        lblMethod    = new Label();
        cmbMethod    = new ComboBox();
        dgv          = new DataGridView();
        pnlBtn       = new Panel();
        btnSave      = new Button();
        btnDelete    = new Button();
        btnClear     = new Button();

        pnlInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        pnlBtn.SuspendLayout();
        SuspendLayout();

        // ── pnlInput ─────────────────────────────────────────────────
        pnlInput.BackColor = Color.WhiteSmoke;
        pnlInput.Dock      = DockStyle.Top;
        pnlInput.Height    = 150;

        lblMemberSub.Text      = "Subscription:";
        lblMemberSub.Location  = new Point(10, 13);
        lblMemberSub.Size      = new Size(95, 23);
        lblMemberSub.TextAlign = ContentAlignment.MiddleRight;
        cmbMemberSub.Location  = new Point(113, 10);
        cmbMemberSub.Size      = new Size(280, 23);
        cmbMemberSub.DropDownStyle = ComboBoxStyle.DropDownList;

        lblAmount.Text      = "Amount:";
        lblAmount.Location  = new Point(10, 48);
        lblAmount.Size      = new Size(95, 23);
        lblAmount.TextAlign = ContentAlignment.MiddleRight;
        nudAmount.Location  = new Point(113, 45);
        nudAmount.Size      = new Size(120, 23);
        nudAmount.Maximum   = 99999;
        nudAmount.DecimalPlaces = 2;

        lblDate.Text      = "Date:";
        lblDate.Location  = new Point(10, 83);
        lblDate.Size      = new Size(95, 23);
        lblDate.TextAlign = ContentAlignment.MiddleRight;
        dtpDate.Location  = new Point(113, 80);
        dtpDate.Size      = new Size(160, 23);
        dtpDate.Format    = DateTimePickerFormat.Short;

        lblMethod.Text      = "Method:";
        lblMethod.Location  = new Point(10, 118);
        lblMethod.Size      = new Size(95, 23);
        lblMethod.TextAlign = ContentAlignment.MiddleRight;
        cmbMethod.Location  = new Point(113, 115);
        cmbMethod.Size      = new Size(140, 23);
        cmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;

        pnlInput.Controls.AddRange(new Control[]
            { lblMemberSub, cmbMemberSub, lblAmount, nudAmount,
              lblDate, dtpDate, lblMethod, cmbMethod });

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
        Text                = "Payments";
        StartPosition       = FormStartPosition.CenterScreen;
        Load               += frmPayments_Load;

        Controls.AddRange(new Control[] { dgv, pnlBtn, pnlInput });

        pnlBtn.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        pnlInput.ResumeLayout(false);
        ResumeLayout(false);
    }

    // ── Control fields ────────────────────────────────────────────────
    private Panel          pnlInput     = null!;
    private Panel          pnlBtn       = null!;
    private Label          lblMemberSub = null!;
    private Label          lblAmount    = null!;
    private Label          lblDate      = null!;
    private Label          lblMethod    = null!;
    private ComboBox       cmbMemberSub = null!;
    private NumericUpDown  nudAmount    = null!;
    private DateTimePicker dtpDate      = null!;
    private ComboBox       cmbMethod    = null!;
    private DataGridView   dgv          = null!;
    private Button         btnSave      = null!;
    private Button         btnDelete    = null!;
    private Button         btnClear     = null!;
}
