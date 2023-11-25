using System;
using finalsProject.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalsProject
{
    public partial class StaffMenu : Form
    {
        public StaffMenu()
        {
            InitializeComponent();
        }
        private void StaffMenu_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
        }

        private void viewcredentialsbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new staffCredentials();
            f.Show();
        }

        private void viewassignedtablebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new staffViewTables();
            f.Show();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new login();
            f.Show();
        }

        private void takeordersbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new StaffChooseTable();
            f.Show();
        }
    }
}
