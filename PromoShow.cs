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
    public partial class PromoShow : Form
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=MEGI\\SQLEXPRESS01;Initial Catalog = CARWASH;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt;
        public PromoShow()
        {
            InitializeComponent();
            LoadPromo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Promo h = new Promo(this);
            h.Show();

        }

        private void dgvHarxhimet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvPromo.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                // To send employer data to the employer module
                Promo module = new Promo(this);

                module.lblEid.Text = dgvPromo.Rows[e.RowIndex].Cells[1].Value.ToString();



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
                            using (SqlCommand cm = new SqlCommand("DELETE FROM Promot WHERE PromoID = @PromoID", con))
                            {
                                cm.Parameters.AddWithValue("@PromoID", dgvPromo.Rows[e.RowIndex].Cells["PromoID"].Value.ToString());
                                cm.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Data has been successfully removed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPromo(); // Reload data after deletion
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

       

        public void LoadPromo()
        {
            try
            {
                adt = new SqlDataAdapter("select * from Promot", con);
                dt = new DataTable();
                adt.Fill(dt);
                dgvPromo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
