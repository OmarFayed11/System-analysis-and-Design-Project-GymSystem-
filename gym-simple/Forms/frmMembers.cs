namespace GymSystem.Forms;

public partial class frmMembers : Form
{
    int _id = 0;

    public frmMembers() => InitializeComponent();

    void frmMembers_Load(object s, EventArgs e)
    {
        var trainers = DB.Query("SELECT Trainer_ID, Name FROM TRAINER ORDER BY Name");
        cmbTrainer.DataSource    = trainers;
        cmbTrainer.DisplayMember = "Name";
        cmbTrainer.ValueMember   = "Trainer_ID";
        cmbTrainer.SelectedIndex = -1;
        Reload();
    }

    void Reload()
    {
        dgv.DataSource = DB.Query(@"
            SELECT m.Member_ID AS ID, m.Name, m.Phone, m.Email, m.Join_Date,
                   t.Name AS Trainer
            FROM   MEMBER m
            LEFT JOIN TRAINER t ON t.Trainer_ID = m.Trainer_ID
            ORDER  BY m.Name");
    }

    void dgv_SelectionChanged(object s, EventArgs e)
    {
        if (dgv.CurrentRow == null) return;
        var r = dgv.CurrentRow;
        _id           = Convert.ToInt32(r.Cells["ID"].Value);
        txtName.Text  = r.Cells["Name"].Value?.ToString();
        txtPhone.Text = r.Cells["Phone"].Value?.ToString();
        txtEmail.Text = r.Cells["Email"].Value?.ToString();

        if (DateTime.TryParse(r.Cells["Join_Date"].Value?.ToString(), out var d))
            dtpJoin.Value = d;

        var trainerName = r.Cells["Trainer"].Value?.ToString();
        cmbTrainer.SelectedIndex = -1;
        foreach (DataGridViewRow row in cmbTrainer.DataSource is System.Data.DataTable dt
            ? dt.Rows.Cast<System.Data.DataRow>()
                     .Select((x, i) => (x, i))
                     .Where(x => x.x["Name"]?.ToString() == trainerName)
                     .Select(x => (DataGridViewRow?)null)   // placeholder
                     .ToList()
            : new List<DataGridViewRow?>())
            { }
        // simpler: iterate combo items
        for (int i = 0; i < cmbTrainer.Items.Count; i++)
        {
            var rowView = cmbTrainer.Items[i] as System.Data.DataRowView;
            if (rowView?["Name"]?.ToString() == trainerName)
                { cmbTrainer.SelectedIndex = i; break; }
        }
    }

    void btnSave_Click(object s, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
            { MessageBox.Show("Name is required."); return; }

        object? tid = cmbTrainer.SelectedIndex >= 0 ? cmbTrainer.SelectedValue : null;

        if (_id == 0)
            DB.Exec("INSERT INTO MEMBER(Name,Phone,Email,Join_Date,Trainer_ID) VALUES(@n,@p,@em,@jd,@tid)",
                ("@n", txtName.Text), ("@p", txtPhone.Text), ("@em", txtEmail.Text),
                ("@jd", dtpJoin.Value.ToString("yyyy-MM-dd")), ("@tid", tid));
        else
            DB.Exec("UPDATE MEMBER SET Name=@n,Phone=@p,Email=@em,Join_Date=@jd,Trainer_ID=@tid WHERE Member_ID=@id",
                ("@n", txtName.Text), ("@p", txtPhone.Text), ("@em", txtEmail.Text),
                ("@jd", dtpJoin.Value.ToString("yyyy-MM-dd")), ("@tid", tid), ("@id", _id));

        Clear(); Reload();
    }

    void btnDelete_Click(object s, EventArgs e)
    {
        if (_id == 0) return;
        if (MessageBox.Show("Delete member?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { DB.Exec("DELETE FROM MEMBER WHERE Member_ID=@id", ("@id", _id)); Clear(); Reload(); }
    }

    void btnClear_Click(object s, EventArgs e) => Clear();

    void Clear()
    {
        _id = 0;
        txtName.Clear(); txtPhone.Clear(); txtEmail.Clear();
        dtpJoin.Value = DateTime.Today;
        cmbTrainer.SelectedIndex = -1;
    }
}
