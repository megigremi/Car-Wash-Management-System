using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CARwashManagementSystem
{
    public partial class Produkte : Form
    {
        private readonly SqlConnection con = new SqlConnection("Data Source=MEGI\\SQLEXPRESS01;Initial Catalog=CARWASH;Integrated Security=True");
        private SqlCommand cmd;
        private SqlDataAdapter adt;
        private DataTable dt;

        public Produkte()
        {
            InitializeComponent();
            LoadProduktet(); // Calling this function when the form starts
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProduktetModule pu = new ProduktetModule(this);
            pu.btnUpdate.Enabled = false; // This is for save, not for update
            pu.ShowDialog();
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProdukte.Columns[e.ColumnIndex].Name;


            if (colName == "Edit")
            {
                // To send product data to the product module
                ProduktetModule module = new ProduktetModule(this);
                module.lblCid.Text = dgvProdukte.Rows[e.RowIndex].Cells[1].Value.ToString();



                module.btnSave.Enabled = false;
                module.ShowDialog();
            }
            else if (colName == "Delete")
            {
                DeleteProduct(e.RowIndex);
            }
        }

        private void DeleteProduct(int rowIndex)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection deleteCon = new SqlConnection("Data Source=MEGI\\SQLEXPRESS01;Initial Catalog=CARWASH;Integrated Security=True"))
                    {
                        deleteCon.Open();
                        using (SqlCommand cm = new SqlCommand("DELETE FROM Produkte WHERE ProduktiID = @ProduktiID", deleteCon))
                        {
                            cm.Parameters.AddWithValue("@ProduktiID", dgvProdukte.Rows[rowIndex].Cells["ProduktiID"].Value.ToString());
                            cm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Product data has been successfully removed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProduktet(); // Reload data after deletion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadProduktet()
        {
            try
            {
                adt = new SqlDataAdapter("SELECT * FROM Produkte", con);
                dt = new DataTable();
                adt.Fill(dt);
                dgvProdukte.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
