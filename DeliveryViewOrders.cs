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
    public partial class DeliveryViewOrders : Form
    {
        public DeliveryViewOrders()
        {
            InitializeComponent();
        }

        private void DeliveryViewOrders_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
            int id = SigninOthers.s.Id;
            List<DeliveryDetails> d = StaffDL.staffviewassignedorders(id);
            if (d != null)
            {
                dataGridView1.DataSource = d;
                dataGridView1.Refresh();
            }
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGoldenrod;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new deliveryManMenu();
            f.Show();
        }
    }
}
