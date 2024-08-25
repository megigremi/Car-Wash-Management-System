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

namespace CARwashManagementSystem
{
    public partial class KlientetModule : Form
    {
        bool check = false;
        Klientet employer;
        public KlientetModule(Klientet emp)
        {
            InitializeComponent();
            employer = emp;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KlientetModule_Load(object sender, EventArgs e)
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
                        SqlCommand cm = new SqlCommand("INSERT INTO Kliente(EmriMBiemri,Telefon,NrMakine,ModeliMakines,LlojiMakines,Adresa,Piket)VALUES(@EmriMbiemri,@Telefon,@NrMakine,@ModeliMakines,@LlojiMakines,@Adresa,@Piket)", con);
                        cm.Parameters.AddWithValue("@EmriMbiemri", txtName.Text);
                        cm.Parameters.AddWithValue("@Telefon", txtPhone.Text);
                        cm.Parameters.AddWithValue("@NrMakine", txtCarNo.Text);
                        cm.Parameters.AddWithValue("@ModeliMakines", txtCarModel.Text);//like if condition
                        cm.Parameters.AddWithValue("@LlojiMakines", cbCarType.Text);
                        cm.Parameters.AddWithValue("@Adresa", txtAddress.Text);
                        cm.Parameters.AddWithValue("@Piket", udPoints.Text);
                       


                        // to open connection
                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("Klienti u rregjistrua me sukses!");
                        check = false;
                        Clear();//to clear data field, after data inserted into the database                        
                        employer.LoadKlientet(); // refresh the employer list after insert data in the table
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
                    if (MessageBox.Show("Are you sure you want to edit this record?", "Editing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cm = new SqlCommand("UPDATE Kliente SET EmriMbiemri=@EmriMbiemri, Telefon=@Telefon, NrMakine=@NrMakine , ModeliMakines=@ModeliMakines,LlojiMakines=@LlojiMakines,Adresa=@Adresa,Piket=@Piket WHERE KlientID=@HKlientID", con);
                        cm.Parameters.AddWithValue("@KlientID", lblCid.Text);
                        cm.Parameters.AddWithValue("@EmriMbiemri", txtName.Text);
                        cm.Parameters.AddWithValue("@Telefon", txtPhone.Text);
                        cm.Parameters.AddWithValue("@NrMakine", txtCarNo.Text);
                        cm.Parameters.AddWithValue("@ModeliMakines", txtCarModel.Text);//like if condition
                        cm.Parameters.AddWithValue("@LlojiMakines", cbCarType.Text);
                        cm.Parameters.AddWithValue("@Adresa", txtAddress.Text);
                        cm.Parameters.AddWithValue("@Piket", udPoints.Text);


                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("SUKSES");
                        Clear();//to clear data field, after data inserted into the database
                        this.Dispose();
                        employer.LoadKlientet();
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
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;

        }

        public void Clear()
        {
            txtAddress.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtCarNo.Clear();
            txtCarModel.Clear();
            

        }

        public void checkField()
        {
            if (txtAddress.Text == "" || txtName.Text == "" || txtPhone.Text == "" || txtCarNo.Text == "" || txtCarModel.Text == "")
            {
                MessageBox.Show("Required data Field!", "Warning");
                return; // return to the data field and form
            }
            check = true;
        }
    }
}
