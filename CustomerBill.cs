using finalsProject.Classes;
using System;
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
    public partial class CustomerBill : Form
    {
        public CustomerBill()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerBill_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            if(SelectDeliveryDetails.orderid != 0)
            {
                DataTable d = OrderItemsDL.retriveorderitem(SelectDeliveryDetails.orderid);
                dataGridView1.DataSource = d;
                int bill = OrderItemsDL.generatecustbill(SelectDeliveryDetails.orderid);
                label5.Text = bill.ToString();
            }
           
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new customerMenu();
            f.Show();
        }
    }
}
