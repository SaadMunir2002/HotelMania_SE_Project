using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finalsProject.Classes;


namespace finalsProject
{
    public partial class customerMenu : Form
    {
        public customerMenu()
        {
            InitializeComponent();
        }

        private void customerMenu_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
        }

        private void viewCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new CustCredentials();
            f.Show();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new CustCredentials();
            f.Show();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            custReserveTable table = new custReserveTable();
            table.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new CustomerOrder();
            f.Show();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Cart();
            f.Show();
        }

        private void adddeliverydetailsbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new AddDeliveyDetails();
            f.Show();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new login();
            f.Show();
        }
    }
}
