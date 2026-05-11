namespace GymSystem.Forms;

public partial class frmTrainers : Form
{
    int _id = 0;

    public frmTrainers() => InitializeComponent();

    void frmTrainers_Load(object s, EventArgs e) => Reload();

    void Reload()
    {
        dgv.DataSource = DB.Query(
            "SELECT Trainer_ID AS ID, Name, Phone, Specialty FROM TRAINER ORDER BY Name");
    }

    void dgv_SelectionChanged(object s, EventArgs e)
    {
        if (dgv.CurrentRow == null) return;
        var r = dgv.CurrentRow;
        _id             = Convert.ToInt32(r.Cells["ID"].Value);
        txtName.Text     = r.Cells["Name"].Value?.ToString();
        txtPhone.Text    = r.Cells["Phone"].Value?.ToString();
        txtSpecialty.Text = r.Cells["Specialty"].Value?.ToString();
    }

    void btnSave_Click(object s, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
            { MessageBox.Show("Name is required."); return; }

        if (_id == 0)
            DB.Exec("INSERT INTO TRAINER(Name,Phone,Specialty) VALUES(@n,@p,@sp)",
                ("@n", txtName.Text), ("@p", txtPhone.Text), ("@sp", txtSpecialty.Text));
        else
            DB.Exec("UPDATE TRAINER SET Name=@n,Phone=@p,Specialty=@sp WHERE Trainer_ID=@id",
                ("@n", txtName.Text), ("@p", txtPhone.Text), ("@sp", txtSpecialty.Text), ("@id", _id));

        Clear(); Reload();
    }

    void btnDelete_Click(object s, EventArgs e)
    {
        if (_id == 0) return;
        if (MessageBox.Show("Delete trainer?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { DB.Exec("DELETE FROM TRAINER WHERE Trainer_ID=@id", ("@id", _id)); Clear(); Reload(); }
    }

    void btnClear_Click(object s, EventArgs e) => Clear();

    void Clear()
    {
        _id = 0;
        txtName.Clear(); txtPhone.Clear(); txtSpecialty.Clear();
    }
}
