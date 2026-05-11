namespace GymSystem.Forms;

public partial class frmPayments : Form
{
    int _receiptNo = 0;

    public frmPayments() => InitializeComponent();

    void frmPayments_Load(object s, EventArgs e)
    {
        cmbMethod.Items.AddRange(new[] { "Cash", "Card", "Online" });
        cmbMethod.SelectedIndex = 0;

        cmbMemberSub.DataSource = DB.Query(@"
            SELECT ms.MS_ID,
                   m.Name || ' – ' || s.Plan_Name AS Label
            FROM   MEMBER_SUBSCRIPTION ms
            JOIN   MEMBER m      ON m.Member_ID = ms.Member_ID
            JOIN   SUBSCRIPTION s ON s.Sub_ID   = ms.Sub_ID
            ORDER  BY m.Name");
        cmbMemberSub.DisplayMember = "Label";
        cmbMemberSub.ValueMember   = "MS_ID";
        cmbMemberSub.SelectedIndex = -1;

        Reload();
    }

    void Reload()
    {
        dgv.DataSource = DB.Query(@"
            SELECT p.Receipt_No, m.Name AS Member, s.Plan_Name AS Plan,
                   p.Amount, p.Payment_Date, p.Method
            FROM   PAYMENT p
            JOIN   MEMBER_SUBSCRIPTION ms ON ms.MS_ID    = p.MS_ID
            JOIN   MEMBER m               ON m.Member_ID = ms.Member_ID
            JOIN   SUBSCRIPTION s         ON s.Sub_ID    = ms.Sub_ID
            ORDER  BY p.Receipt_No DESC");
    }

    void dgv_SelectionChanged(object s, EventArgs e)
    {
        if (dgv.CurrentRow == null) return;
        var r = dgv.CurrentRow;
        _receiptNo = Convert.ToInt32(r.Cells["Receipt_No"].Value);

        nudAmount.Value = Convert.ToDecimal(r.Cells["Amount"].Value);
        if (DateTime.TryParse(r.Cells["Payment_Date"].Value?.ToString(), out var d)) dtpDate.Value = d;

        var method = r.Cells["Method"].Value?.ToString();
        cmbMethod.SelectedItem = cmbMethod.Items.Contains(method) ? method : "Cash";

        // match member-sub combo by member + plan
        var label = $"{r.Cells["Member"].Value} – {r.Cells["Plan"].Value}";
        for (int i = 0; i < cmbMemberSub.Items.Count; i++)
        {
            if ((cmbMemberSub.Items[i] as System.Data.DataRowView)?["Label"]?.ToString() == label)
                { cmbMemberSub.SelectedIndex = i; break; }
        }
    }

    void btnSave_Click(object s, EventArgs e)
    {
        if (cmbMemberSub.SelectedIndex < 0)
            { MessageBox.Show("Select a member subscription."); return; }

        var msId   = cmbMemberSub.SelectedValue;
        var amount = (double)nudAmount.Value;
        var date   = dtpDate.Value.ToString("yyyy-MM-dd");
        var method = cmbMethod.SelectedItem?.ToString();

        if (_receiptNo == 0)
            DB.Exec("INSERT INTO PAYMENT(MS_ID,Amount,Payment_Date,Method) VALUES(@ms,@am,@dt,@me)",
                ("@ms", msId), ("@am", amount), ("@dt", date), ("@me", method));
        else
            DB.Exec("UPDATE PAYMENT SET MS_ID=@ms,Amount=@am,Payment_Date=@dt,Method=@me WHERE Receipt_No=@rn",
                ("@ms", msId), ("@am", amount), ("@dt", date), ("@me", method), ("@rn", _receiptNo));

        Clear(); Reload();
    }

    void btnDelete_Click(object s, EventArgs e)
    {
        if (_receiptNo == 0) return;
        if (MessageBox.Show("Delete payment?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { DB.Exec("DELETE FROM PAYMENT WHERE Receipt_No=@rn", ("@rn", _receiptNo)); Clear(); Reload(); }
    }

    void btnClear_Click(object s, EventArgs e) => Clear();

    void Clear()
    {
        _receiptNo = 0;
        cmbMemberSub.SelectedIndex = -1;
        nudAmount.Value = 0;
        dtpDate.Value   = DateTime.Today;
        cmbMethod.SelectedIndex = 0;
    }
}
