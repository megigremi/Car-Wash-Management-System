using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CARwashManagementSystem
{
    public partial class ProduktetModule : Form
    {
        bool check = false;
        Produkte employer;
        public ProduktetModule(Produkte emp)
        {
            InitializeComponent();
            employer = emp;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProduktetModule_Load(object sender, EventArgs e)
        {

        }



        public void Clear()
        {
            txtEmriProduktit.Clear();
            txtCmimi.Clear();
            txtSasia.Clear();
          

        }
    

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            try
            {
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Are you sure you want to register this employer?", "Employer Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlConnection con = new SqlConnection("Data Source = MEGI\\SQLEXPRESS01; Initial Catalog = CARWASH; Integrated Security = True");
                        con.Open();
                        SqlCommand cm = new SqlCommand("INSERT INTO Produkte(Emri,Cmimi,Sasia,Produkti_Totali,Date) VALUES(@Emri,@cmimi,@Sasia, @Produkti_Totali,@Date)", con);
                        cm.Parameters.AddWithValue("@Emri", txtEmriProduktit.Text);
                        cm.Parameters.AddWithValue("@Cmimi", txtCmimi.Text);
                        cm.Parameters.AddWithValue("@Sasia", txtSasia.Text);
                        cm.Parameters.AddWithValue("@Produkti_Totali", Convert.ToDecimal(txtSasia.Text) * Convert.ToDecimal(txtCmimi.Text));
                        cm.Parameters.AddWithValue("@Date", dtDob.Value);
                        // to open connection
                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("Produkt has been successfully registered!");
                        check = false;
                        Clear();//to clear data field, after data inserted into the database                        
                        employer.LoadProduktet(); // refresh the employer list after insert data in the table
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                checkField();
                if (check)
                {
                    SqlConnection con = new SqlConnection("Data Source=MEGI\\SQLEXPRESS01;Initial Catalog = CARWASH;Integrated Security=True");
                    con.Open();
                    if (MessageBox.Show("Are you sure you want to edit this record?", "Employer Editing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cm = new SqlCommand("UPDATE Produkte SET Emri=@Emri, Cmimi=@Cmimi, Sasia=@Sasia,Produkti_Totali=@Produkti_Totali Date=@Date WHERE ProduktiID=@ProduktiID", con);
                        cm.Parameters.AddWithValue("@ProduktiID", lblCid.Text);
                        cm.Parameters.AddWithValue("@Emri", txtEmriProduktit.Text);
                        cm.Parameters.AddWithValue("@Cmimi", txtCmimi.Text);
                        cm.Parameters.AddWithValue("@Sasia", txtSasia.Text);
                        cm.Parameters.AddWithValue("@Produkti_Totali", Convert.ToDecimal(txtSasia.Text) * Convert.ToDecimal(txtCmimi.Text));
                        cm.Parameters.AddWithValue("@Date", dtDob.Value);

                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("Employer has been successfully Update!");
                        Clear();//to clear data field, after data inserted into the database
                        this.Dispose();
                        employer.LoadProduktet();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Clear();
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;


        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void checkField()
        {
            if (txtEmriProduktit.Text == "" || txtCmimi.Text == "" || txtSasia.Text == "")
            {
                MessageBox.Show("Required data Field!", "Warning");
                return; // return to the data field and form
            }
            check = true;
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
