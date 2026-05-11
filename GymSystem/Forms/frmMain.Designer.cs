namespace GymSystem.Forms;

partial class frmMain
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlCenter        = new Panel();
        flp              = new FlowLayoutPanel();
        lblTitle         = new Label();
        btnTrainers      = new Button();
        btnMembers       = new Button();
        btnSubscriptions = new Button();
        btnMemberSubs    = new Button();
        btnPayments      = new Button();
        btnReviews       = new Button();
        btnReports       = new Button();

        pnlCenter.SuspendLayout();
        flp.SuspendLayout();
        SuspendLayout();

        // ── FlowLayoutPanel: stacks buttons top-to-bottom, auto-sized ─
        flp.AutoSize      = true;
        flp.AutoSizeMode  = AutoSizeMode.GrowAndShrink;
        flp.FlowDirection = FlowDirection.TopDown;
        flp.WrapContents  = false;

        // Title label (full-width inside the flow panel)
        lblTitle.Text      = "Gym Management System";
        lblTitle.Font      = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblTitle.Size      = new Size(240, 40);
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        lblTitle.Margin    = new Padding(0, 0, 0, 10);

        // Helper: configure each button uniformly
        void MakeBtn(Button b, string text, EventHandler handler)
        {
            b.Text    = text;
            b.Size    = new Size(240, 38);
            b.Margin  = new Padding(0, 0, 0, 8);
            b.Click  += handler;
        }

        MakeBtn(btnTrainers,      "Trainers",              btnTrainers_Click);
        MakeBtn(btnMembers,       "Members",               btnMembers_Click);
        MakeBtn(btnSubscriptions, "Subscription Plans",    btnSubscriptions_Click);
        MakeBtn(btnMemberSubs,    "Member Subscriptions",  btnMemberSubs_Click);
        MakeBtn(btnPayments,      "Payments",              btnPayments_Click);
        MakeBtn(btnReviews,       "Reviews",               btnReviews_Click);
        MakeBtn(btnReports,       "Reports",               btnReports_Click);

        flp.Controls.AddRange(new Control[]
        {
            lblTitle,
            btnTrainers, btnMembers, btnSubscriptions,
            btnMemberSubs, btnPayments, btnReviews, btnReports
        });

        // ── pnlCenter: fills the form and keeps flp centered ──────────
        pnlCenter.Dock = DockStyle.Fill;
        pnlCenter.Controls.Add(flp);
        // Re-center flp whenever the panel size changes
        pnlCenter.Resize += (s, e) =>
        {
            flp.Location = new Point(
                (pnlCenter.Width  - flp.Width)  / 2,
                (pnlCenter.Height - flp.Height) / 2);
        };

        // ── Form ──────────────────────────────────────────────────────
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode       = AutoScaleMode.Font;
        ClientSize          = new Size(380, 480);
        MinimumSize         = new Size(300, 400);
        Text                = "Gym System";
        StartPosition       = FormStartPosition.CenterScreen;  // centers on any screen

        Controls.Add(pnlCenter);

        flp.ResumeLayout(false);
        pnlCenter.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    // ── Control fields ────────────────────────────────────────────────
    private Panel          pnlCenter        = null!;
    private FlowLayoutPanel flp             = null!;
    private Label          lblTitle         = null!;
    private Button         btnTrainers      = null!;
    private Button         btnMembers       = null!;
    private Button         btnSubscriptions = null!;
    private Button         btnMemberSubs    = null!;
    private Button         btnPayments      = null!;
    private Button         btnReviews       = null!;
    private Button         btnReports       = null!;
}
