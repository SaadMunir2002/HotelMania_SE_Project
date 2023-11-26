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
    public partial class deliveryManMenu : Form
    {
        public deliveryManMenu()
        {
            InitializeComponent();
        }

        private void deliveryManMenu_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
        }

        private void viewcedentialsbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new staffCredentials();
            f.Show();
        }

        private void viewassignedordersbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new DeliveryViewOrders();
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
