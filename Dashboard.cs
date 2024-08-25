using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARwashManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnEmployer_Click(object sender, EventArgs e)
        {
            loadform(new Puntoret());

            

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            loadform(new Klientet());
        }

       

        private void btncash_Click(object sender, EventArgs e)
        {
            loadform(new Produkte());
            

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            loadform(new Report());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            loadform(new Harxhimet());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void loadform(object Form)
        {
            if (this.panel3.Controls.Count > 0) this.panel3.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(f);
            this.panel3.Tag = f;
            f.Show();

        }

        public void loadform2(object Form)
        {
            if (this.panel6.Controls.Count > 0) this.panel6.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel6.Controls.Add(f);
            this.panel6.Tag = f;
            f.Show();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
           

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnService_Click_1(object sender, EventArgs e)
        {
            loadform2(new SherbimetModule(this));
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel6.Controls.Clear();

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            loadform(new Dashboard2());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
