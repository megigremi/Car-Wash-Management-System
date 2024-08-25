using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CARwashManagementSystem
{

    public partial class Dashboard2 : Form
    {


        private DashboardClass model;
        private Button currentButton;


        public Dashboard2()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            btnLast7Days.Select();

            SetDAteMenuButton(btnLast7Days);
            model = new DashboardClass();
            LoadData();


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard2_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            var refreshData = model.LoadData(dtpStartDate.Value, dtpEndDate.Value);
            if (refreshData == true)
            {
                lblNumOrders.Text = model.NumOrders.ToString();
                lblTotalRevenue.Text = "$" + model.TotalRevenue.ToString();
                lblTotalProfit.Text = "$" + model.TotalProfit.ToString();

                lblNumCustomers.Text = model.NumCustomers.ToString();
                lblNumSuppliers.Text = model.NumSuppliers.ToString();
                lblNumProducts.Text = model.NumProducts.ToString();

                // Update chartGrossRevenue binding
                chartGrossRevenue.DataSource = model.GrossRevenueList;
                chartGrossRevenue.Series[0].XValueMember = "Date"; // Use the Date property
                chartGrossRevenue.Series[0].YValueMembers = "TotalAmount"; // Use the TotalAmount property
                chartGrossRevenue.DataBind();

                // Update chartTopProducts binding
                chartTopProducts.DataSource = model.TopProductsList;
                chartTopProducts.Series[0].XValueMember = "Key";
                chartTopProducts.Series[0].YValueMembers = "Value";
                chartTopProducts.DataBind();


            }
            else Console.WriteLine("View not loaded, same query");
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            btnOkCustomDate.Visible = true;
        }
        private void DisableCustomDates()
        {
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            btnOkCustomDate.Visible = false;
        }

     
     

        private void btnToday_Click(object sender, EventArgs e)
        {
            SetDAteMenuButton(sender);
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();

        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
            SetDAteMenuButton(sender);


        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
            SetDAteMenuButton(sender);

        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
           

        }

        private void SetDAteMenuButton(object button)
        {
            var btn = (Button)button;
            btn.BackColor = btnLast30Days.FlatAppearance.BorderColor;
            btn.ForeColor = Color.White;

            if(currentButton != null && currentButton != btn)
            {
                currentButton.BackColor = this.BackColor;
                currentButton.ForeColor = Color.FromArgb(124, 141, 181);
            }

            currentButton = btn;
        }

        private void btnOkCustomDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
