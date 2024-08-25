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
    public partial class Programet : Form
    {
        bool check = false;
        ProgrametShow employer;
        public Programet(ProgrametShow emp)
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
                        SqlCommand cm = new SqlCommand("INSERT INTO Programe(ProgramP1,ProgramP2,ProgramP3,ProgramP4,AbonnementP1,AbonnementP2,AbonnementP3,AbonnementP4,PassageP1,PassageP2,PassageP3,PassageP4,Date,TotaliPro,TotaliAbo,TotaliPG,TotaliPAP1,TotaliPAP2,TotaliPAP3,TotaliPAP4,TotaliCol1,TotaliCol2,TotaliCol3,TotaliCol4,TotaliRowT,TotaliPAPT,Moyenne)" +
                                                       "VALUES(@ProgramP1,@ProgramP2,@ProgramP3,@ProgramP4,@AbonnementP1,@AbonnementP2,@AbonnementP3,@AbonnementP4,@PassageP1,@PassageP2,@PassageP3,@PassageP4,@Date,@TotaliPro,@TotaliAbo,@TotaliPG,@TotaliPAP1,@TotaliPAP2,@TotaliPAP3,@TotaliPAP4,@TotaliCol1,@TotaliCol2,@TotaliCol3,@TotaliCol4,@TotaliRowT,@TotaliPAPT,@Moyenne)", con);
                        
                      
                        cm.Parameters.AddWithValue("@ProgramP1", txtPro1.Text);
                        cm.Parameters.AddWithValue("@ProgramP2", txtPro2.Text);
                        cm.Parameters.AddWithValue("@ProgramP3", txtPro3.Text);
                        cm.Parameters.AddWithValue("@ProgramP4", txtPro4.Text);
                        
                        cm.Parameters.AddWithValue("@AbonnementP1", txtAbo1.Text);
                        cm.Parameters.AddWithValue("@AbonnementP2", txtAbo2.Text);
                        cm.Parameters.AddWithValue("@AbonnementP3", txtAbo3.Text);
                        cm.Parameters.AddWithValue("@AbonnementP4", txtAbo4.Text);
                        
                        cm.Parameters.AddWithValue("@PassageP1", txtPG1.Text);
                        cm.Parameters.AddWithValue("@PassageP2", txtPG2.Text);
                        cm.Parameters.AddWithValue("@PassageP3", txtPG3.Text);
                        cm.Parameters.AddWithValue("@PassageP4", txtPG4.Text);
                       
                        cm.Parameters.AddWithValue("@Date", dtCoG.Value);
                                   
                        cm.Parameters.AddWithValue("@TotaliPro", Convert.ToDecimal(txtPro1.Text)  + Convert.ToDecimal(txtPro2.Text) + Convert.ToDecimal(txtPro3.Text)  + Convert.ToDecimal(txtPro4.Text));
                        cm.Parameters.AddWithValue("@TotaliAbo", Convert.ToDecimal(txtAbo1.Text) + Convert.ToDecimal(txtAbo2.Text) + Convert.ToDecimal(txtAbo3.Text) + Convert.ToDecimal(txtAbo4.Text));
                        cm.Parameters.AddWithValue("@TotaliPG", Convert.ToDecimal(txtPG1.Text) + Convert.ToDecimal(txtPG2.Text) + Convert.ToDecimal(txtPG3.Text) + Convert.ToDecimal(txtPG4.Text));

                        cm.Parameters.AddWithValue("@TotaliCol1", Convert.ToDecimal(txtPro1.Text) + Convert.ToDecimal(txtAbo1.Text) + Convert.ToDecimal(txtPG1.Text));
                        cm.Parameters.AddWithValue("@TotaliCol2", Convert.ToDecimal(txtPro2.Text) + Convert.ToDecimal(txtAbo2.Text) + Convert.ToDecimal(txtPG2.Text));
                        cm.Parameters.AddWithValue("@TotaliCol3", Convert.ToDecimal(txtPro3.Text) + Convert.ToDecimal(txtAbo3.Text) + Convert.ToDecimal(txtPG3.Text));
                        cm.Parameters.AddWithValue("@TotaliCol4", Convert.ToDecimal(txtPro4.Text) + Convert.ToDecimal(txtAbo4.Text) + Convert.ToDecimal(txtPG4.Text));

                        decimal TotalRow14 = (Convert.ToDecimal(txtPro1.Text) - Convert.ToDecimal(txtAbo1.Text) - Convert.ToDecimal(txtPG1.Text)) +
                                                                 (Convert.ToDecimal(txtPro2.Text) - Convert.ToDecimal(txtAbo2.Text) - Convert.ToDecimal(txtPG2.Text)) +
                                                                 (Convert.ToDecimal(txtPro3.Text) - Convert.ToDecimal(txtAbo3.Text) - Convert.ToDecimal(txtPG3.Text)) +
                                                                 (Convert.ToDecimal(txtPro4.Text) - Convert.ToDecimal(txtAbo4.Text) - Convert.ToDecimal(txtPG4.Text));

                        cm.Parameters.AddWithValue("@TotaliRowT", TotalRow14);

                        cm.Parameters.AddWithValue("@TotaliPAP1", (Convert.ToDecimal(txtPro1.Text)*10) - (Convert.ToDecimal(txtAbo1.Text)*10) - (Convert.ToDecimal(txtPG1.Text)*10));
                        cm.Parameters.AddWithValue("@TotaliPAP2", (Convert.ToDecimal(txtPro2.Text) * 12) - (Convert.ToDecimal(txtAbo2.Text) * 12) - (Convert.ToDecimal(txtPG2.Text)*12));
                        cm.Parameters.AddWithValue("@TotaliPAP3", (Convert.ToDecimal(txtPro3.Text) * 14) - (Convert.ToDecimal(txtAbo3.Text) * 14) - (Convert.ToDecimal(txtPG3.Text)*14));
                        cm.Parameters.AddWithValue("@TotaliPAP4", (Convert.ToDecimal(txtPro4.Text) * 16) - (Convert.ToDecimal(txtAbo4.Text) * 16) - (Convert.ToDecimal(txtPG4.Text) * 16));

                       

                        decimal totalPAP = ((Convert.ToDecimal(txtPro1.Text) * 10) - (Convert.ToDecimal(txtAbo1.Text) * 10) - (Convert.ToDecimal(txtPG1.Text) * 10)) +
                                                               ((Convert.ToDecimal(txtPro2.Text) * 12) - (Convert.ToDecimal(txtAbo2.Text) * 12) - (Convert.ToDecimal(txtPG2.Text) * 12)) +
                                                               ((Convert.ToDecimal(txtPro3.Text) * 14) - ((Convert.ToDecimal(txtAbo3.Text) * 14) - (Convert.ToDecimal(txtPG3.Text) * 14)) +
                                                               ((Convert.ToDecimal(txtPro4.Text) * 16) - (Convert.ToDecimal(txtAbo4.Text) * 16) - (Convert.ToDecimal(txtPG4.Text) * 16)));


                        cm.Parameters.AddWithValue("@TotaliPAPT", totalPAP);

                        cm.Parameters.AddWithValue("@Moyenne", ((totalPAP+TotalRow14)/2));



                        // to open connection
                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("Employer has been successfully registered!");
                        check = false;
                        Clear();//to clear data field, after data inserted into the database                        
                        employer.LoadProgramet(); // refresh the employer list after insert data in the table
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
                        SqlCommand cm = new SqlCommand("UPDATE Programe SET ProgramP1=@ProgramP1,ProgramP2=@ProgramP2,ProgramP3=@ProgramP3,ProgramP4=@ProgramP4,AbonnementP1=@AbonnementP1,AbonnementP2=@AbonnementP2,AbonnementP3=@AbonnementP3,AbonnementP4=@AbonnementP4,PassageP1=@PassageP1,PassageP2=@PassageP2,PassageP3=@PassageP3,PassageP4=@PassageP4," +
                                                        "Date=@Date,TotaliPro=@TotaliPro,TotaliAbo=@TotaliAbo,TotaliPG=@TotaliPG,TotaliPAP1=@TotaliPAP1,TotaliPAP2=@TotaliPAP2,TotaliPAP3=@TotaliPAP3,TotaliPAP4=@TotaliPAP4,TotaliCol1=@TotaliCol1,TotaliCol2=@TotaliCol2,TotaliCol3=@TotaliCol3,TotaliCol4=@TotaliCol4,TotaliRowT=@TotaliRowT,TotaliPAPT=@TotaliPAPT,Moyenne=@Moyenne WHERE ProgrametID=@ProgrametID", con);
                        cm.Parameters.AddWithValue("@ProgrametID", lblCid.Text);
                        cm.Parameters.AddWithValue("@ProgramP1", txtPro1.Text);
                        cm.Parameters.AddWithValue("@ProgramP2", txtPro2.Text);
                        cm.Parameters.AddWithValue("@ProgramP3", txtPro3.Text);
                        cm.Parameters.AddWithValue("@ProgramP4", txtPro4.Text);

                        cm.Parameters.AddWithValue("@AbonnementP1", txtAbo1.Text);
                        cm.Parameters.AddWithValue("@AbonnementP2", txtAbo2.Text);
                        cm.Parameters.AddWithValue("@AbonnementP3", txtAbo3.Text);
                        cm.Parameters.AddWithValue("@AbonnementP4", txtAbo4.Text);

                        cm.Parameters.AddWithValue("@PassageP1", txtPG1.Text);
                        cm.Parameters.AddWithValue("@PassageP2", txtPG2.Text);
                        cm.Parameters.AddWithValue("@PassageP3", txtPG3.Text);
                        cm.Parameters.AddWithValue("@PassageP4", txtPG4.Text);

                        cm.Parameters.AddWithValue("@Date", dtCoG.Value);

                        cm.Parameters.AddWithValue("@TotaliPro", Convert.ToDecimal(txtPro1.Text) + Convert.ToDecimal(txtPro2.Text) + Convert.ToDecimal(txtPro3.Text) + Convert.ToDecimal(txtPro4.Text));
                        cm.Parameters.AddWithValue("@TotaliAbo", Convert.ToDecimal(txtAbo1.Text) + Convert.ToDecimal(txtAbo2.Text) + Convert.ToDecimal(txtAbo3.Text) + Convert.ToDecimal(txtAbo4.Text));
                        cm.Parameters.AddWithValue("@TotaliPG", Convert.ToDecimal(txtPG1.Text) + Convert.ToDecimal(txtPG2.Text) + Convert.ToDecimal(txtPG3.Text) + Convert.ToDecimal(txtPG4.Text));

                        cm.Parameters.AddWithValue("@TotaliCol1", Convert.ToDecimal(txtPro1.Text) + Convert.ToDecimal(txtAbo1.Text) + Convert.ToDecimal(txtPG1.Text));
                        cm.Parameters.AddWithValue("@TotaliCol2", Convert.ToDecimal(txtPro2.Text) + Convert.ToDecimal(txtAbo2.Text) + Convert.ToDecimal(txtPG2.Text));
                        cm.Parameters.AddWithValue("@TotaliCol3", Convert.ToDecimal(txtPro3.Text) + Convert.ToDecimal(txtAbo3.Text) + Convert.ToDecimal(txtPG3.Text));
                        cm.Parameters.AddWithValue("@TotaliCol4", Convert.ToDecimal(txtPro4.Text) + Convert.ToDecimal(txtAbo4.Text) + Convert.ToDecimal(txtPG4.Text));

                        cm.Parameters.AddWithValue("@TotaliRowT", (Convert.ToDecimal(txtPro1.Text) - Convert.ToDecimal(txtAbo1.Text) - Convert.ToDecimal(txtPG1.Text)) +
                                                                  (Convert.ToDecimal(txtPro2.Text) - Convert.ToDecimal(txtAbo2.Text) - Convert.ToDecimal(txtPG2.Text)) +
                                                                  (Convert.ToDecimal(txtPro3.Text) - Convert.ToDecimal(txtAbo3.Text) - Convert.ToDecimal(txtPG3.Text)) +
                                                                  (Convert.ToDecimal(txtPro4.Text) - Convert.ToDecimal(txtAbo4.Text) - Convert.ToDecimal(txtPG4.Text)));

                        cm.Parameters.AddWithValue("@TotaliPAP1", (Convert.ToDecimal(txtPro1.Text) * 10) - (Convert.ToDecimal(txtAbo1.Text) * 10) - (Convert.ToDecimal(txtPG1.Text) * 10));
                        cm.Parameters.AddWithValue("@TotaliPAP2", (Convert.ToDecimal(txtPro2.Text) * 12) - (Convert.ToDecimal(txtAbo2.Text) * 12) - (Convert.ToDecimal(txtPG2.Text) * 12));
                        cm.Parameters.AddWithValue("@TotaliPAP3", (Convert.ToDecimal(txtPro3.Text) * 14) - (Convert.ToDecimal(txtAbo3.Text) * 14) - (Convert.ToDecimal(txtPG3.Text) * 14));
                        cm.Parameters.AddWithValue("@TotaliPAP4", (Convert.ToDecimal(txtPro4.Text) * 16) - (Convert.ToDecimal(txtAbo4.Text) * 16) - (Convert.ToDecimal(txtPG4.Text) * 16));

                        cm.Parameters.AddWithValue("@TotaliPAPT", ((Convert.ToDecimal(txtPro1.Text) * 10) - (Convert.ToDecimal(txtAbo1.Text) * 10) - (Convert.ToDecimal(txtPG1.Text) * 10)) +
                                                               ((Convert.ToDecimal(txtPro2.Text) * 12) - (Convert.ToDecimal(txtAbo2.Text) * 12) - (Convert.ToDecimal(txtPG2.Text) * 12)) +
                                                               ((Convert.ToDecimal(txtPro3.Text) * 14) - ((Convert.ToDecimal(txtAbo3.Text) * 14) - (Convert.ToDecimal(txtPG3.Text) * 14)) +
                                                               ((Convert.ToDecimal(txtPro4.Text) * 16) - (Convert.ToDecimal(txtAbo4.Text) * 16) - (Convert.ToDecimal(txtPG4.Text) * 16))));

                       





                        cm.ExecuteNonQuery();
                        con.Close();// to close connection
                        MessageBox.Show("Employer has been successfully registered!");
                        Clear();//to clear data field, after data inserted into the database
                        this.Dispose();
                        employer.LoadProgramet();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Clear()
        {
            txtPro1.Clear();
            txtPro2.Clear();
            txtPro3.Clear();
            txtPro4.Clear();

            txtAbo1.Clear();
            txtAbo2.Clear();
            txtAbo3.Clear();
            txtAbo4.Clear();

            txtPG1.Clear();
            txtPG2.Clear();
            txtPG3.Clear();
            txtPG4.Clear();


        }
        public void checkField()
        {
            if (txtPro1.Text == "" || txtPro2.Text == "" || txtPro3.Text == "" || txtPro4.Text == "" ||
                txtAbo1.Text == "" || txtAbo2.Text == ""|| txtAbo3.Text == ""|| txtAbo4.Text == ""||
                txtPG1.Text == "" || txtPG2.Text == "" || txtPG3.Text == "" || txtPG4.Text == "")
            {
                MessageBox.Show("Required data Field!", "Warning");
                return; // return to the data field and form
            }

           
            check = true;
        }

        private void Totali_Click(object sender, EventArgs e)
        {
            decimal Pro1 = Convert.ToDecimal(txtPro1.Text);
            decimal Pro2 = Convert.ToDecimal(txtPro2.Text);
            decimal Pro3 = Convert.ToDecimal(txtPro3.Text);
            decimal Pro4 = Convert.ToDecimal(txtPro4.Text);

            decimal Prototal = Pro1   + Pro2 + Pro3 + Pro4;
            txtProT.Text = Prototal.ToString();


            decimal Abo1 = Convert.ToDecimal(txtAbo1.Text);
            decimal Abo2 = Convert.ToDecimal(txtAbo2.Text);
            decimal Abo3 = Convert.ToDecimal(txtAbo3.Text);
            decimal Abo4 = Convert.ToDecimal(txtAbo4.Text);

            decimal Abototal = Abo1 + Abo2 + Abo3 + Abo4;
            txtAboT.Text = Abototal.ToString();


            decimal PG1 = Convert.ToDecimal(txtPG1.Text);
            decimal PG2 = Convert.ToDecimal(txtPG1.Text);
            decimal PG3 = Convert.ToDecimal(txtPG1.Text);
            decimal PG4 = Convert.ToDecimal(txtPG1.Text);

            decimal PGtotal = PG1 + PG2 + PG3 + PG4;
            txtPGT.Text = PGtotal.ToString();

            decimal TotalRow1 = Pro1 - Abo1 - PG1;
            decimal TotalRow2 = Pro2 - Abo2 - PG2;
            decimal TotalRow3 = Pro3 - Abo3 - PG3;
            decimal TotalRow4 = Pro4 - Abo4 - PG4;

            TotaliRow1.Text = TotalRow1.ToString();
            TotaliRow2.Text = TotalRow2.ToString();
            TotaliRow3.Text = TotalRow3.ToString();
            TotaliRow4.Text= TotalRow4.ToString();

            decimal TotaliRowT = TotalRow1 + TotalRow2 + TotalRow3 + TotalRow4;

            TotaliRow.Text= TotaliRowT.ToString();

            decimal TotalPAP1 = (Pro1 * 10) - (Abo1 * 10) - (PG1 * 10);
            decimal TotalPAP2 = (Pro2 * 12) - (Abo2 * 12) - (PG2 * 12);
            decimal TotalPAP3 = (Pro3 * 14) - (Abo3 * 14) - (PG3 * 14);
            decimal TotalPAP4 = (Pro4 * 16) - (Abo4 * 16) - (PG4 * 16);

            TotaliPAP1.Text = TotalPAP1.ToString();
            TotaliPAP2.Text = TotalPAP2.ToString();
            TotaliPAP3.Text = TotalPAP3.ToString();
            TotaliPAP4.Text = TotalPAP4.ToString();

            decimal TotalPAPT = TotalPAP1 + TotalPAP2 + TotalPAP3 + TotalPAP4;

            TotaliPAPT.Text = TotalPAPT.ToString();

            
            decimal average = (TotalPAPT + TotaliRowT) / 2;

            textMoyenne.Text = average.ToString();






        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
