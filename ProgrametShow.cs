using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CARwashManagementSystem
{
    public partial class ProgrametShow : Form
    {

        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=MEGI\\SQLEXPRESS01;Initial Catalog = CARWASH;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt;

        public ProgrametShow()
        {
            InitializeComponent();
            LoadProgramet();
        }

        private void dgvEmployer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = dgvEmployer.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                // To send employer data to the employer module
                Programet module = new Programet(this);
                module.lblCid.Text = dgvEmployer.Rows[e.RowIndex].Cells[1].Value.ToString();



                module.btnSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "Delete")
            {
                // If you want to delete the record by clicking the delete icon on the DataGridView
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (SqlConnection con = new SqlConnection("Data Source=MEGI\\SQLEXPRESS01;Initial Catalog = CARWASH;Integrated Security=True"))
                        {
                            con.Open();
                            using (SqlCommand cm = new SqlCommand("DELETE FROM Programe WHERE ProgrametID = @ProgrametID", con))
                            {
                                cm.Parameters.AddWithValue("@ProgrametID", dgvEmployer.Rows[e.RowIndex].Cells["ProgrametID"].Value.ToString());
                                cm.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Employer data has been successfully removed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProgramet(); // Reload data after deletion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Programet pu = new Programet(this);
            pu.btnUpdate.Enabled = false; // This is for save, not for update
            pu.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        public void LoadProgramet()
        {
            try
            {
                adt = new SqlDataAdapter("select * from Programe", con);
                dt = new DataTable();
                adt.Fill(dt);
                dgvEmployer.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
