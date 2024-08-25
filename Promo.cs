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
    public partial class Promo : Form
    {
        bool check = false;
        PromoShow employer;
        public Promo(PromoShow emp)
        {
            InitializeComponent();
            employer = emp;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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
                        SqlCommand cm = new SqlCommand("INSERT INTO Promot(Promo1, Promo2,Promo3,Promo4,Promo5,Promo6,Promo7,Promo8,Promo9,Promo10,Comment,Data,Promo_Totali1,Promo_Totali2,Promo_Totali3,Promo_Totali4,Promo_Totali5,Promo_Totali6,Promo_Totali7,Promo_Totali8,Promo_Totali9,Promo_Totali10)" +
                                                       "VALUES(@Promo1,@Promo2,@Promo3,@Promo4,@Promo5,@Promo6,@Promo7,@Promo8,@Promo9,@Promo10,@Comment,@Data,@Promo_Totali1,@Promo_Totali2,@Promo_Totali3,@Promo_Totali4,@Promo_Totali5,@Promo_Totali6,@Promo_Totali7,@Promo_Totali8,@Promo_Totali9,@Promo_Totali10)", con);
                        cm.Parameters.AddWithValue("@Promo1", txt1.Text);
                        cm.Parameters.AddWithValue("@Promo2", txt2.Text);
                        cm.Parameters.AddWithValue("@Promo3", txt3.Text);
                        cm.Parameters.AddWithValue("@Data", dtDob.Value);
                        cm.Parameters.AddWithValue("@Promo4", txt4.Text);
                        cm.Parameters.AddWithValue("@Promo5", txt5.Text);
                        cm.Parameters.AddWithValue("@Promo6", txt6.Text);
                        cm.Parameters.AddWithValue("@Promo7", txt7.Text);
                        cm.Parameters.AddWithValue("@Promo8", txt8.Text);
                        cm.Parameters.AddWithValue("@Promo9", txt9.Text);
                        cm.Parameters.AddWithValue("@Promo10", txt10.Text);
                        cm.Parameters.AddWithValue("@Comment", txtComment.Text);

                        

                        cm.Parameters.AddWithValue("@Promo_Totali1", Convert.ToDecimal(txtTotali1.Text) * (-1));
                        cm.Parameters.AddWithValue("@Promo_Totali2", Convert.ToDecimal(txtTotali2.Text) * (-2));
                        cm.Parameters.AddWithValue("@Promo_Totali3", Convert.ToDecimal(txtTotali3.Text) * (-3));
                        cm.Parameters.AddWithValue("@Promo_Totali4", Convert.ToDecimal(txtTotali4.Text) * (-4));
                        cm.Parameters.AddWithValue("@Promo_Totali5", Convert.ToDecimal(txtTotali5.Text) * (-5));
                        cm.Parameters.AddWithValue("@Promo_Totali6", Convert.ToDecimal(txtTotali6.Text) * (-6));
                        cm.Parameters.AddWithValue("@Promo_Totali7", Convert.ToDecimal(txtTotali7.Text) * (-7));
                        cm.Parameters.AddWithValue("@Promo_Totali8", Convert.ToDecimal(txtTotali8.Text) * (-8));
                        cm.Parameters.AddWithValue("@Promo_Totali9", Convert.ToDecimal(txtTotali9.Text) * (-9));
                        cm.Parameters.AddWithValue("@Promo_Totali10", Convert.ToDecimal(txtTotali10.Text) * (-10));





                        // to open connection
                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("Successfully registered!");
                        check = false;
                        Clear();//to clear data field, after data inserted into the database                        
                        employer.LoadPromo(); // refresh the employer list after insert data in the table
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
                        SqlCommand cm = new SqlCommand("UPDATE Promot SET Promo1=@Promo1, Promo2=@Promo2, Promo3=@Promo3,Data=@Data, Promo4=@Promo4, Promo5=@Promo5, Promo6=@Promo6, Promo7=@Promo7, Promo8=@Promo8, Promo9=@Promo9, Promo10=@Promo10, Comment=@Comment," +
                                                       "Promo_Totali1=@Promo_Totali1,Promo_Totali2=@Promo_Totali2,Promo_Totali3=@Promo_Totali3,Promo_Totali4=@Promo_Totali4,Promo_Totali5=@Promo_Totali5,Promo_Totali6=@Promo_Totali6,Promo_Totali7=@Promo_Totali7,Promo_Totali8=@Promo_Totali8,Promo_Totali9=@Promo_Totali9,Promo_Totali10=@Promo_Totali10" +
                                                       "WHERE PromoID=@PromoID", con);

                        cm.Parameters.AddWithValue("@PromoID", lblEid.Text);
                        cm.Parameters.AddWithValue("@Promo1", txt1.Text);
                        cm.Parameters.AddWithValue("@Promo2", txt2.Text);
                        cm.Parameters.AddWithValue("@Promo3", txt3.Text);
                        cm.Parameters.AddWithValue("@Data", dtDob.Value);
                        cm.Parameters.AddWithValue("@Promo4", txt4.Text);
                        cm.Parameters.AddWithValue("@Promo5", txt5.Text);
                        cm.Parameters.AddWithValue("@Promo6", txt6.Text);
                        cm.Parameters.AddWithValue("@Promo7", txt7.Text);
                        cm.Parameters.AddWithValue("@Promo8", txt8.Text);
                        cm.Parameters.AddWithValue("@Promo9", txt9.Text);
                        cm.Parameters.AddWithValue("@Promo10", txt10.Text);
                        cm.Parameters.AddWithValue("@Comment", txtComment.Text);

                        cm.Parameters.AddWithValue("@Promo_Totali1", Convert.ToDecimal(txtTotali1.Text) * (-1));
                        cm.Parameters.AddWithValue("@Promo_Totali2", Convert.ToDecimal(txtTotali2.Text) * (-2));
                        cm.Parameters.AddWithValue("@Promo_Totali3", Convert.ToDecimal(txtTotali3.Text) * (-3));
                        cm.Parameters.AddWithValue("@Promo_Totali4", Convert.ToDecimal(txtTotali4.Text) * (-4));
                        cm.Parameters.AddWithValue("@Promo_Totali5", Convert.ToDecimal(txtTotali5.Text) * (-5));
                        cm.Parameters.AddWithValue("@Promo_Totali6", Convert.ToDecimal(txtTotali6.Text) * (-6));
                        cm.Parameters.AddWithValue("@Promo_Totali7", Convert.ToDecimal(txtTotali7.Text) * (-7));
                        cm.Parameters.AddWithValue("@Promo_Totali8", Convert.ToDecimal(txtTotali8.Text) * (-8));
                        cm.Parameters.AddWithValue("@Promo_Totali9", Convert.ToDecimal(txtTotali9.Text) * (-9));
                        cm.Parameters.AddWithValue("@Promo_Totali10", Convert.ToDecimal(txtTotali10.Text) * (-10));

                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("Sucesful!");
                        Clear();//to clear data field, after data inserted into the database
                        this.Dispose();
                        employer.LoadPromo();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public void Clear()
        {
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
            txt4.Clear();
            txt5.Clear();
            txt6.Clear();
            txt7.Clear();
            txt8.Clear();
            txt9.Clear();
            txt10.Clear();

            dtDob.Value = DateTime.Now;

        }
        public void checkField()
        {
            if (txt1.Text == "" || txt2.Text == "" || txt3.Text == "" || txt4.Text == "" || txt5.Text == ""
                 || txt6.Text == "" || txt7.Text == "" || txt8.Text == "" || txt9.Text == "" || txt10.Text == "")
            {
                MessageBox.Show("Required data Field!", "Warning");
                return; // return to the data field and form
            }


            check = true;
        }

        private void Calculate_btn_Click(object sender, EventArgs e)
        {
            decimal p_Totali1 = (Convert.ToDecimal(txt1.Text) * (-1));
            decimal p_Totali2 = (Convert.ToDecimal(txt2.Text) * (-2));
            decimal p_Totali3 = (Convert.ToDecimal(txt3.Text) * (-3));
            decimal p_Totali4 = (Convert.ToDecimal(txt4.Text) * (-4));
            decimal p_Totali5 = (Convert.ToDecimal(txt5.Text) * (-5));
            decimal p_Totali6 = (Convert.ToDecimal(txt6.Text) * (-6));
            decimal p_Totali7 = (Convert.ToDecimal(txt7.Text) * (-7));
            decimal p_Totali8 = (Convert.ToDecimal(txt8.Text) * (-8));
            decimal p_Totali9 = (Convert.ToDecimal(txt9.Text) * (-9));
            decimal p_Totali10 = (Convert.ToDecimal(txt10.Text) * (-10));


            txtTotali1.Text = p_Totali1.ToString();
            txtTotali2.Text = p_Totali2.ToString();
            txtTotali3.Text = p_Totali3.ToString();
            txtTotali4.Text = p_Totali4.ToString();
            txtTotali5.Text = p_Totali5.ToString();
            txtTotali6.Text = p_Totali6.ToString();
            txtTotali7.Text = p_Totali7.ToString();
            txtTotali8.Text = p_Totali8.ToString();
            txtTotali9.Text = p_Totali9.ToString();
            txtTotali10.Text = p_Totali10.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
