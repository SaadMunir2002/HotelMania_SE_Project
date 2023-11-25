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
    public partial class ManagerMenu : Form
    {
        public ManagerMenu()
        {
            InitializeComponent();
        }

        private void ManagerMenu_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new login();
            f.Show();
        }

        private void staffbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new AddStaff();
            f.Show();
        }

        private void tablebtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new AddTables();
            f.Show();
        }

        private void menubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new AddMenus();
            f.Show();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new AddFoodCategories();
            f.Show();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new AssignTableToStaff();
            f.Show();
        }

        private void assigndeliveryordersbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Assigndeliveryorders();
            f.Show();
        }
        private void billbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new BillGeneration();
            f.Show();
        }

        private void ordersbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
