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
    public partial class BakshisheShow : Form
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection("Data Source=MEGI\\SQLEXPRESS01;Initial Catalog = CARWASH;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt;

        public BakshisheShow()
        {
            InitializeComponent();
            LoadBakshishet();
        }

        private void dgvEmployer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBakshishe.Columns[e.ColumnIndex].Name;

            if (colName == "Edit")
            {
                // To send employer data to the employer module
                Bakshishe module = new Bakshishe(this);
                

                module.txtCaisse.Text = dgvBakshishe.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.txtName.Text = dgvBakshishe.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.textBc.Text = dgvBakshishe.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.textBanqueT.Text = dgvBakshishe.Rows[e.RowIndex].Cells[6].Value.ToString();
                




                module.button1.Enabled = false;
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
                            using (SqlCommand cm = new SqlCommand("DELETE FROM Bakshish WHERE BakshishID = @BakshishID", con))
                            {
                                cm.Parameters.AddWithValue("@BakshishID", dgvBakshishe.Rows[e.RowIndex].Cells["BakshishID"].Value.ToString());
                                cm.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("E dhena u eleminua me sukses", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBakshishet(); // Reload data after deletion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Bakshishe pu = new Bakshishe(this);
            pu.btnUpdate.Enabled = false; // This is for save, not for update
            pu.ShowDialog();
        }


        public void LoadBakshishet()
        {
            try
            {
                adt = new SqlDataAdapter("select * from Bakshish", con);
                dt = new DataTable();
                adt.Fill(dt);
                dgvBakshishe.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
