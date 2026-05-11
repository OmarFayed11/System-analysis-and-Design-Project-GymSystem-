namespace GymSystem.Forms;

public partial class frmReviews : Form
{
    int _id = 0;

    public frmReviews() => InitializeComponent();

    void frmReviews_Load(object s, EventArgs e)
    {
        cmbMember.DataSource    = DB.Query("SELECT Member_ID, Name FROM MEMBER ORDER BY Name");
        cmbMember.DisplayMember = "Name";
        cmbMember.ValueMember   = "Member_ID";
        cmbMember.SelectedIndex = -1;

        cmbMemberSub.DataSource = DB.Query(@"
            SELECT ms.MS_ID,
                   m.Name || ' – ' || s.Plan_Name AS Label
            FROM   MEMBER_SUBSCRIPTION ms
            JOIN   MEMBER m       ON m.Member_ID = ms.Member_ID
            JOIN   SUBSCRIPTION s ON s.Sub_ID    = ms.Sub_ID
            ORDER  BY m.Name");
        cmbMemberSub.DisplayMember = "Label";
        cmbMemberSub.ValueMember   = "MS_ID";
        cmbMemberSub.SelectedIndex = -1;

        Reload();
    }

    void Reload()
    {
        dgv.DataSource = DB.Query(@"
            SELECT r.Review_ID AS ID, m.Name AS Member, s.Plan_Name AS Plan,
                   r.Score, r.Comment
            FROM   REVIEW r
            JOIN   MEMBER m               ON m.Member_ID = r.Member_ID
            JOIN   MEMBER_SUBSCRIPTION ms ON ms.MS_ID    = r.MS_ID
            JOIN   SUBSCRIPTION s         ON s.Sub_ID    = ms.Sub_ID
            ORDER  BY r.Review_ID DESC");
    }

    void dgv_SelectionChanged(object s, EventArgs e)
    {
        if (dgv.CurrentRow == null) return;
        var r = dgv.CurrentRow;
        _id = Convert.ToInt32(r.Cells["ID"].Value);
        nudScore.Value = Convert.ToDecimal(r.Cells["Score"].Value);
        txtComment.Text = r.Cells["Comment"].Value?.ToString();

        SelectCombo(cmbMember,    "Name",      r.Cells["Member"].Value?.ToString());
        SelectCombo(cmbMemberSub, "Label",
            $"{r.Cells["Member"].Value} – {r.Cells["Plan"].Value}");
    }

    static void SelectCombo(ComboBox cmb, string field, string? val)
    {
        cmb.SelectedIndex = -1;
        if (val == null) return;
        for (int i = 0; i < cmb.Items.Count; i++)
        {
            if ((cmb.Items[i] as System.Data.DataRowView)?[field]?.ToString() == val)
                { cmb.SelectedIndex = i; return; }
        }
    }

    void btnSave_Click(object s, EventArgs e)
    {
        if (cmbMember.SelectedIndex < 0 || cmbMemberSub.SelectedIndex < 0)
            { MessageBox.Show("Select member and subscription."); return; }

        var mem   = cmbMember.SelectedValue;
        var ms    = cmbMemberSub.SelectedValue;
        var score = (double)nudScore.Value;
        var cmt   = txtComment.Text;

        if (_id == 0)
            DB.Exec("INSERT INTO REVIEW(Member_ID,MS_ID,Score,Comment) VALUES(@m,@ms,@sc,@cm)",
                ("@m", mem), ("@ms", ms), ("@sc", score), ("@cm", cmt));
        else
            DB.Exec("UPDATE REVIEW SET Member_ID=@m,MS_ID=@ms,Score=@sc,Comment=@cm WHERE Review_ID=@id",
                ("@m", mem), ("@ms", ms), ("@sc", score), ("@cm", cmt), ("@id", _id));

        Clear(); Reload();
    }

    void btnDelete_Click(object s, EventArgs e)
    {
        if (_id == 0) return;
        if (MessageBox.Show("Delete review?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { DB.Exec("DELETE FROM REVIEW WHERE Review_ID=@id", ("@id", _id)); Clear(); Reload(); }
    }

    void btnClear_Click(object s, EventArgs e) => Clear();

    void Clear()
    {
        _id = 0;
        cmbMember.SelectedIndex    = -1;
        cmbMemberSub.SelectedIndex = -1;
        nudScore.Value  = 3;
        txtComment.Clear();
    }
}
