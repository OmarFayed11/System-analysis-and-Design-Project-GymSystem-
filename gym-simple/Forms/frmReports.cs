namespace GymSystem.Forms;

public partial class frmReports : Form
{
    public frmReports() => InitializeComponent();

    void frmReports_Load(object s, EventArgs e)
    {
        cmbReport.Items.AddRange(new[]
        {
            "All Members with Trainer",
            "All Member Subscriptions",
            "All Payments",
            "All Reviews with Score",
            "Revenue per Plan"
        });
        cmbReport.SelectedIndex = 0;
    }

    void btnLoad_Click(object s, EventArgs e)
    {
        dgv.DataSource = cmbReport.SelectedIndex switch
        {
            0 => DB.Query(@"
                    SELECT m.Member_ID, m.Name, m.Phone, m.Email, m.Join_Date,
                           t.Name AS Trainer
                    FROM   MEMBER m
                    LEFT JOIN TRAINER t ON t.Trainer_ID = m.Trainer_ID
                    ORDER  BY m.Name"),

            1 => DB.Query(@"
                    SELECT ms.MS_ID, m.Name AS Member, s.Plan_Name AS Plan,
                           ms.Start_Date, ms.End_Date
                    FROM   MEMBER_SUBSCRIPTION ms
                    JOIN   MEMBER m       ON m.Member_ID = ms.Member_ID
                    JOIN   SUBSCRIPTION s ON s.Sub_ID    = ms.Sub_ID
                    ORDER  BY ms.MS_ID DESC"),

            2 => DB.Query(@"
                    SELECT p.Receipt_No, m.Name AS Member, s.Plan_Name AS Plan,
                           p.Amount, p.Payment_Date, p.Method
                    FROM   PAYMENT p
                    JOIN   MEMBER_SUBSCRIPTION ms ON ms.MS_ID    = p.MS_ID
                    JOIN   MEMBER m               ON m.Member_ID = ms.Member_ID
                    JOIN   SUBSCRIPTION s         ON s.Sub_ID    = ms.Sub_ID
                    ORDER  BY p.Receipt_No DESC"),

            3 => DB.Query(@"
                    SELECT r.Review_ID, m.Name AS Member, s.Plan_Name AS Plan,
                           r.Score, r.Comment
                    FROM   REVIEW r
                    JOIN   MEMBER m               ON m.Member_ID = r.Member_ID
                    JOIN   MEMBER_SUBSCRIPTION ms ON ms.MS_ID    = r.MS_ID
                    JOIN   SUBSCRIPTION s         ON s.Sub_ID    = ms.Sub_ID
                    ORDER  BY r.Score DESC"),

            4 => DB.Query(@"
                    SELECT s.Plan_Name AS Plan,
                           COUNT(p.Receipt_No) AS Payments,
                           SUM(p.Amount)       AS Total_Revenue
                    FROM   PAYMENT p
                    JOIN   MEMBER_SUBSCRIPTION ms ON ms.MS_ID = p.MS_ID
                    JOIN   SUBSCRIPTION s         ON s.Sub_ID = ms.Sub_ID
                    GROUP  BY s.Plan_Name
                    ORDER  BY Total_Revenue DESC"),

            _ => new System.Data.DataTable()
        };
    }
}
