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
    public partial class ManagerViewOrders : Form
    {
        public ManagerViewOrders()
        {
            InitializeComponent();
        }

        private void staffViewOrders_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";

            DataTable dt = OrderDL.managervieworders();
            dataGridView1.DataSource = dt;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new ManagerMenu();
            f.Show();
        }
    }
}
