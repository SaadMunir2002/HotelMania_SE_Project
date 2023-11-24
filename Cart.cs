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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finalsProject
{
    public partial class Cart : Form
    {
        DataTable d;
        public Cart()
        {
            InitializeComponent();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            
            ShowIcon = false;
            Text = "";
            /*DataGridView dataGridView1 = this.dataGridView1;

            // Get a reference to the data source
            BindingSource bindingSource1 = (BindingSource)dataGridView1.DataSource;

            // Clear the data source
            if(bindingSource1 != null)
            {
                bindingSource1.Clear();

                // Refresh the datagrid control
                dataGridView1.Refresh();
            }*/

            dataGridView1.AutoGenerateColumns = false;
            // MessageBox.Show(SelectDeliveryDetails.orderid.ToString());
            if(d != null)
            {
                d.Clear();
                dataGridView1.Refresh();
            }
            d = OrderItemsDL.retriveorderitem(SelectDeliveryDetails.orderid);
            dataGridView1.DataSource = d;
            
           
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Form f = new CustomerBill();
                f.Show();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
          
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new customerMenu();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
