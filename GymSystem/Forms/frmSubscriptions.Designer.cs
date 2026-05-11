namespace GymSystem.Forms;

partial class frmSubscriptions
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlInput   = new Panel();
        lblPlan    = new Label();
        txtPlan    = new TextBox();
        lblMonths  = new Label();
        nudMonths  = new NumericUpDown();
        lblPrice   = new Label();
        nudPrice   = new NumericUpDown();
        dgv        = new DataGridView();
        pnlBtn     = new Panel();
        btnSave    = new Button();
        btnDelete  = new Button();
        btnClear   = new Button();

        pnlInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudMonths).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        pnlBtn.SuspendLayout();
        SuspendLayout();

        // ── pnlInput ─────────────────────────────────────────────────
        pnlInput.BackColor = Color.WhiteSmoke;
        pnlInput.Dock      = DockStyle.Top;
        pnlInput.Height    = 115;

        lblPlan.Text      = "Plan Name:";
        lblPlan.Location  = new Point(10, 13);
        lblPlan.Size      = new Size(90, 23);
        lblPlan.TextAlign = ContentAlignment.MiddleRight;
        txtPlan.Location  = new Point(108, 10);
        txtPlan.Size      = new Size(240, 23);

        lblMonths.Text      = "Months:";
        lblMonths.Location  = new Point(10, 48);
        lblMonths.Size      = new Size(90, 23);
        lblMonths.TextAlign = ContentAlignment.MiddleRight;
        nudMonths.Location  = new Point(108, 45);
        nudMonths.Size      = new Size(80, 23);
        nudMonths.Minimum   = 1;
        nudMonths.Maximum   = 120;
        nudMonths.Value     = 1;

        lblPrice.Text      = "Price:";
        lblPrice.Location  = new Point(10, 83);
        lblPrice.Size      = new Size(90, 23);
        lblPrice.TextAlign = ContentAlignment.MiddleRight;
        nudPrice.Location  = new Point(108, 80);
        nudPrice.Size      = new Size(120, 23);
        nudPrice.Maximum   = 99999;
        nudPrice.DecimalPlaces = 2;

        pnlInput.Controls.AddRange(new Control[]
            { lblPlan, txtPlan, lblMonths, nudMonths, lblPrice, nudPrice });

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
        ClientSize          = new Size(680, 480);
        Text                = "Subscription Plans";
        StartPosition       = FormStartPosition.CenterScreen;
        Load               += frmSubscriptions_Load;

        Controls.AddRange(new Control[] { dgv, pnlBtn, pnlInput });

        pnlBtn.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudMonths).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        pnlInput.ResumeLayout(false);
        ResumeLayout(false);
    }

    // ── Control fields ────────────────────────────────────────────────
    private Panel          pnlInput  = null!;
    private Panel          pnlBtn    = null!;
    private Label          lblPlan   = null!;
    private Label          lblMonths = null!;
    private Label          lblPrice  = null!;
    private TextBox        txtPlan   = null!;
    private NumericUpDown  nudMonths = null!;
    private NumericUpDown  nudPrice  = null!;
    private DataGridView   dgv       = null!;
    private Button         btnSave   = null!;
    private Button         btnDelete = null!;
    private Button         btnClear  = null!;
}
