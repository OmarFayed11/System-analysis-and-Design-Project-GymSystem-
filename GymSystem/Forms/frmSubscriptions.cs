namespace GymSystem.Forms;

public partial class frmSubscriptions : Form
{
    int _id = 0;

    public frmSubscriptions() => InitializeComponent();

    void frmSubscriptions_Load(object s, EventArgs e) => Reload();

    void Reload()
    {
        dgv.DataSource = DB.Query(
            "SELECT Sub_ID AS ID, Plan_Name, Duration_Months AS Months, Price FROM SUBSCRIPTION ORDER BY Plan_Name");
    }

    void dgv_SelectionChanged(object s, EventArgs e)
    {
        if (dgv.CurrentRow == null) return;
        var r = dgv.CurrentRow;
        _id              = Convert.ToInt32(r.Cells["ID"].Value);
        txtPlan.Text     = r.Cells["Plan_Name"].Value?.ToString();
        nudMonths.Value  = Convert.ToDecimal(r.Cells["Months"].Value);
        nudPrice.Value   = Convert.ToDecimal(r.Cells["Price"].Value);
    }

    void btnSave_Click(object s, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtPlan.Text))
            { MessageBox.Show("Plan name is required."); return; }

        if (_id == 0)
            DB.Exec("INSERT INTO SUBSCRIPTION(Plan_Name,Duration_Months,Price) VALUES(@pl,@mo,@pr)",
                ("@pl", txtPlan.Text), ("@mo", (int)nudMonths.Value), ("@pr", (double)nudPrice.Value));
        else
            DB.Exec("UPDATE SUBSCRIPTION SET Plan_Name=@pl,Duration_Months=@mo,Price=@pr WHERE Sub_ID=@id",
                ("@pl", txtPlan.Text), ("@mo", (int)nudMonths.Value), ("@pr", (double)nudPrice.Value), ("@id", _id));

        Clear(); Reload();
    }

    void btnDelete_Click(object s, EventArgs e)
    {
        if (_id == 0) return;
        if (MessageBox.Show("Delete plan?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { DB.Exec("DELETE FROM SUBSCRIPTION WHERE Sub_ID=@id", ("@id", _id)); Clear(); Reload(); }
    }

    void btnClear_Click(object s, EventArgs e) => Clear();

    void Clear()
    {
        _id = 0;
        txtPlan.Clear(); nudMonths.Value = 1; nudPrice.Value = 0;
    }
}
