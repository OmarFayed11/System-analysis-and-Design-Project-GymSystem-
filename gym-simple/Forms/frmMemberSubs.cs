namespace GymSystem.Forms;

public partial class frmMemberSubs : Form
{
    int _id = 0;

    public frmMemberSubs() => InitializeComponent();

    void frmMemberSubs_Load(object s, EventArgs e)
    {
        cmbMember.DataSource    = DB.Query("SELECT Member_ID, Name FROM MEMBER ORDER BY Name");
        cmbMember.DisplayMember = "Name";
        cmbMember.ValueMember   = "Member_ID";
        cmbMember.SelectedIndex = -1;

        cmbSub.DataSource    = DB.Query("SELECT Sub_ID, Plan_Name FROM SUBSCRIPTION ORDER BY Plan_Name");
        cmbSub.DisplayMember = "Plan_Name";
        cmbSub.ValueMember   = "Sub_ID";
        cmbSub.SelectedIndex = -1;

        Reload();
    }

    void Reload()
    {
        dgv.DataSource = DB.Query(@"
            SELECT ms.MS_ID AS ID, m.Name AS Member, s.Plan_Name AS Plan,
                   ms.Start_Date, ms.End_Date
            FROM   MEMBER_SUBSCRIPTION ms
            JOIN   MEMBER m ON m.Member_ID = ms.Member_ID
            JOIN   SUBSCRIPTION s ON s.Sub_ID = ms.Sub_ID
            ORDER  BY ms.MS_ID DESC");
    }

    void dgv_SelectionChanged(object s, EventArgs e)
    {
        if (dgv.CurrentRow == null) return;
        var r = dgv.CurrentRow;
        _id = Convert.ToInt32(r.Cells["ID"].Value);

        SelectCombo(cmbMember, "Name",      r.Cells["Member"].Value?.ToString());
        SelectCombo(cmbSub,    "Plan_Name", r.Cells["Plan"].Value?.ToString());

        if (DateTime.TryParse(r.Cells["Start_Date"].Value?.ToString(), out var sd)) dtpStart.Value = sd;
        if (DateTime.TryParse(r.Cells["End_Date"].Value?.ToString(),   out var ed)) dtpEnd.Value   = ed;
    }

    // Finds combo row by display value and selects it
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
        if (cmbMember.SelectedIndex < 0 || cmbSub.SelectedIndex < 0)
            { MessageBox.Show("Select member and plan."); return; }

        var mem  = cmbMember.SelectedValue;
        var sub  = cmbSub.SelectedValue;
        var sd   = dtpStart.Value.ToString("yyyy-MM-dd");
        var ed   = dtpEnd.Value.ToString("yyyy-MM-dd");

        if (_id == 0)
            DB.Exec("INSERT INTO MEMBER_SUBSCRIPTION(Member_ID,Sub_ID,Start_Date,End_Date) VALUES(@m,@s,@sd,@ed)",
                ("@m", mem), ("@s", sub), ("@sd", sd), ("@ed", ed));
        else
            DB.Exec("UPDATE MEMBER_SUBSCRIPTION SET Member_ID=@m,Sub_ID=@s,Start_Date=@sd,End_Date=@ed WHERE MS_ID=@id",
                ("@m", mem), ("@s", sub), ("@sd", sd), ("@ed", ed), ("@id", _id));

        Clear(); Reload();
    }

    void btnDelete_Click(object s, EventArgs e)
    {
        if (_id == 0) return;
        if (MessageBox.Show("Delete record?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { DB.Exec("DELETE FROM MEMBER_SUBSCRIPTION WHERE MS_ID=@id", ("@id", _id)); Clear(); Reload(); }
    }

    void btnClear_Click(object s, EventArgs e) => Clear();

    void Clear()
    {
        _id = 0;
        cmbMember.SelectedIndex = -1;
        cmbSub.SelectedIndex    = -1;
        dtpStart.Value = DateTime.Today;
        dtpEnd.Value   = DateTime.Today.AddMonths(1);
    }
}
