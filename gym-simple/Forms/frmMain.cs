namespace GymSystem.Forms;

public partial class frmMain : Form
{
    public frmMain() => InitializeComponent();

    void btnTrainers_Click(object s, EventArgs e)      => new frmTrainers().ShowDialog();
    void btnMembers_Click(object s, EventArgs e)       => new frmMembers().ShowDialog();
    void btnSubscriptions_Click(object s, EventArgs e) => new frmSubscriptions().ShowDialog();
    void btnMemberSubs_Click(object s, EventArgs e)    => new frmMemberSubs().ShowDialog();
    void btnPayments_Click(object s, EventArgs e)      => new frmPayments().ShowDialog();
    void btnReviews_Click(object s, EventArgs e)       => new frmReviews().ShowDialog();
    void btnReports_Click(object s, EventArgs e)       => new frmReports().ShowDialog();
}
