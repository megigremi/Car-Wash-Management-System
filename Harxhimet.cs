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

    public partial class Harxhimet : Form
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=MEGI\\SQLEXPRESS01;Initial Catalog = CARWASH;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt;
        public Harxhimet()
        {
            InitializeComponent();
            LoadHarxhimet();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            HarxhimetModuke h = new HarxhimetModuke(this);
            h.Show();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvHarxhimet.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                // To send employer data to the employer module
               HarxhimetModuke module = new HarxhimetModuke(this);
                module.lblCid.Text = dgvHarxhimet.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtCostName.Text = dgvHarxhimet.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.txtCost.Text = dgvHarxhimet.Rows[e.RowIndex].Cells[3].Value.ToString();
               




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
                            using (SqlCommand cm = new SqlCommand("DELETE FROM Harxhimet WHERE HarxhimeID = @HarxhimeID", con))
                            {
                                cm.Parameters.AddWithValue("@HarxhimeID", dgvHarxhimet.Rows[e.RowIndex].Cells["HarxhimeID"].Value.ToString());
                                cm.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Employer data has been successfully removed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHarxhimet(); // Reload data after deletion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        public void LoadHarxhimet()
        {
            try
            {
                adt = new SqlDataAdapter("select * from Harxhimet", con);
                dt = new DataTable();
                adt.Fill(dt);
                dgvHarxhimet.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
