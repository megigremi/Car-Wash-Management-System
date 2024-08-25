using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARwashManagementSystem
{
    public partial class Klientet : Form
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=MEGI\\SQLEXPRESS01;Initial Catalog = CARWASH;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt;
        public Klientet()
        {
            InitializeComponent();
            LoadKlientet();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            KlientetModule pu = new KlientetModule(this);
            pu.btnUpdate.Enabled = false; // This is for save, not for update
            pu.ShowDialog();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvKlient.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                // To send employer data to the employer module
                KlientetModule module = new KlientetModule(this);
                module.lblCid.Text = dgvKlient.Rows[e.RowIndex].Cells[1].Value.ToString();
            
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
                            using (SqlCommand cm = new SqlCommand("DELETE FROM Kliente WHERE KlientID = @KlientID", con))
                            {
                                cm.Parameters.AddWithValue("@KlientID", dgvKlient.Rows[e.RowIndex].Cells["KlientID"].Value.ToString());
                                cm.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("U fshi me sukses!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKlientet(); // Reload data after deletion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        public void LoadKlientet()
        {
            try
            {
                adt = new SqlDataAdapter("select * from Kliente", con);
                dt = new DataTable();
                adt.Fill(dt);
                dgvKlient.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
