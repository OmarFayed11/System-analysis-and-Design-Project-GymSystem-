namespace GymSystem.Forms;

partial class frmReports
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlTop     = new Panel();
        lblReport  = new Label();
        cmbReport  = new ComboBox();
        btnLoad    = new Button();
        dgv        = new DataGridView();

        pnlTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        SuspendLayout();

        // ── pnlTop ───────────────────────────────────────────────────
        pnlTop.BackColor = Color.WhiteSmoke;
        pnlTop.Dock      = DockStyle.Top;
        pnlTop.Height    = 50;

        lblReport.Text      = "Report:";
        lblReport.Location  = new Point(10, 13);
        lblReport.Size      = new Size(60, 23);
        lblReport.TextAlign = ContentAlignment.MiddleRight;

        cmbReport.Location      = new Point(78, 10);
        cmbReport.Size          = new Size(350, 23);
        cmbReport.DropDownStyle = ComboBoxStyle.DropDownList;

        btnLoad.Text     = "Load";
        btnLoad.Location = new Point(440, 10);
        btnLoad.Size     = new Size(75, 28);
        btnLoad.Click   += btnLoad_Click;

        pnlTop.Controls.AddRange(new Control[] { lblReport, cmbReport, btnLoad });

        // ── dgv ──────────────────────────────────────────────────────
        dgv.Dock                = DockStyle.Fill;
        dgv.ReadOnly            = true;
        dgv.AllowUserToAddRows  = false;
        dgv.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // ── Form ─────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode       = AutoScaleMode.Font;
        ClientSize          = new Size(800, 500);
        Text                = "Reports";
        StartPosition       = FormStartPosition.CenterScreen;
        Load               += frmReports_Load;

        Controls.AddRange(new Control[] { dgv, pnlTop });

        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        pnlTop.ResumeLayout(false);
        ResumeLayout(false);
    }

    // ── Control fields ────────────────────────────────────────────────
    private Panel        pnlTop    = null!;
    private Label        lblReport = null!;
    private ComboBox     cmbReport = null!;
    private Button       btnLoad   = null!;
    private DataGridView dgv       = null!;
}
