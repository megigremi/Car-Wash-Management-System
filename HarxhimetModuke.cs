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
    public partial class HarxhimetModuke : Form
    {

        bool check = false;
        Harxhimet employer;
        public HarxhimetModuke(Harxhimet emp)
        {
            InitializeComponent();
            employer = emp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HarxhimetModuke_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
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
                        SqlCommand cm = new SqlCommand("INSERT INTO Harxhimet(EmriHarxhimit,Kosto,Data,Harxhimet_Totali)VALUES(@EmriHarxhimit,@Kosto,@Data,@Harxhimet_Totali)", con);
                        cm.Parameters.AddWithValue("@EmriHarxhimit", txtCostName.Text);
                        cm.Parameters.AddWithValue("@Kosto", txtCost.Text);
                        cm.Parameters.AddWithValue("@Data", dtCoG.Value);
                        cm.Parameters.AddWithValue("@Harxhimet_Totali", Convert.ToDecimal(txtCost.Text) * (-1));




                        // to open connection
                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("Employer has been successfully registered!");
                        check = false;
                        Clear();//to clear data field, after data inserted into the database                        
                        employer.LoadHarxhimet(); // refresh the employer list after insert data in the table
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
                        SqlCommand cm = new SqlCommand("UPDATE Harxhimet SET EmriHarxhimit=@EmriHarxhimit, Kosto=@Kosto, Data=@Data,Harxhimet_Totali=@Harxhimet_Totali WHERE HarxhimeID=@HarxhimeID", con);
                        cm.Parameters.AddWithValue("@HarxhimeID", lblCid.Text);
                        cm.Parameters.AddWithValue("@EmriHarxhimit", txtCostName.Text);
                        cm.Parameters.AddWithValue("@Kosto", txtCost.Text);
                        cm.Parameters.AddWithValue("@Data", dtCoG.Value);
                        cm.Parameters.AddWithValue("@Harxhimet_Totali", Convert.ToDecimal(txtCost.Text) * (-1));


                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("Sukses!");
                        Clear();//to clear data field, after data inserted into the database
                        this.Dispose();
                        employer.LoadHarxhimet();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();

        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow digit number
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal 
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public void checkField()
        {
            if (txtCostName.Text == "" || txtCost.Text == "")
            {
                MessageBox.Show("Required data field!", "Warning");
                return; // return to the data field and form
            }
            check = true;
        }
        public void Clear()
        {
            txtCost.Clear();
            txtCostName.Clear();
            dtCoG.Value = DateTime.Now;

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
    }
}
