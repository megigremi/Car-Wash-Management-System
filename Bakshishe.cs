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
    public partial class Bakshishe : Form
    {
        bool check = false;
        BakshisheShow employer;
        public Bakshishe(BakshisheShow emp)
        {
            InitializeComponent();
            employer = emp;
        }




        public void Clear()
        {
            txtCaisse.Clear();
            txtName.Clear();
            textBc.Clear();
            textBanqueT.Clear();
           

            dtDob.Value = DateTime.Now;



        }

        public void checkField()
        {
            if (txtCaisse.Text == "" || txtName.Text == "" || textBc.Text == "" || textBanqueT.Text == "")
            {
                MessageBox.Show("Required data Field!", "Warning");
                return; // return to the data field and form
            }

            
            check = true;
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                checkField();
                if (check)
                {
                    if (MessageBox.Show("Are you sure you want to register this?", "Employer Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlConnection con = new SqlConnection("Data Source = MEGI\\SQLEXPRESS01; Initial Catalog = CARWASH; Integrated Security = True");
                        con.Open();
                        SqlCommand cm = new SqlCommand("INSERT INTO Bakshish(Bakshish,Data,Caisse,BC,BanqueTotale,Bakshish_Totali)VALUES(@Bakshish,@Data,@Caisse,@BC,@BanqueTotale,@Bakshish_Totali)", con);
                        cm.Parameters.AddWithValue("@Bakshish", txtName.Text);
                        cm.Parameters.AddWithValue("@Data", dtDob.Value);
                        cm.Parameters.AddWithValue("@Caisse", txtCaisse.Text);
                        cm.Parameters.AddWithValue("@BC", textBc.Text);
                        cm.Parameters.AddWithValue("@BanqueTotale", textBanqueT.Text);
                        cm.Parameters.AddWithValue("@Bakshish_Totali", Convert.ToDecimal(txtCaisse.Text) + Convert.ToDecimal(textBc.Text) + Convert.ToDecimal(textBanqueT.Text));



                        // to open connection
                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("U rregjistrua me sukses!");
                        check = false;
                        Clear();//to clear data field, after data inserted into the database                        
                        employer.LoadBakshishet(); // refresh the employer list after insert data in the table
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
                    if (MessageBox.Show("Are you sure you want to edit this record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cm = new SqlCommand("UPDATE Bakshish SET Bakshish=@Bakshish, Data=@Data, Caisse=@Caisse, BC=@BC, BanqueTotale=@BanqueTotale Bakshish_Totali=@Bakshish_Totali WHERE BakshishID=@BakshishID", con);
                        cm.Parameters.AddWithValue("@BakshishID", lblEid.Text);
                        cm.Parameters.AddWithValue("@Bakshish", txtName.Text);
                        cm.Parameters.AddWithValue("@Data", dtDob.Value);
                        cm.Parameters.AddWithValue("@Caisse", txtCaisse.Text);
                        cm.Parameters.AddWithValue("@BC", textBc.Text);
                        cm.Parameters.AddWithValue("@BanqueTotale", textBanqueT.Text);
                        cm.Parameters.AddWithValue("@Bakshish_Totali", Convert.ToDecimal(txtCaisse.Text) + Convert.ToDecimal(textBc.Text) + Convert.ToDecimal(textBanqueT.Text));




                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("Update me sukses");
                        Clear();//to clear data field, after data inserted into the database
                        this.Dispose();
                        employer.LoadBakshishet();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
