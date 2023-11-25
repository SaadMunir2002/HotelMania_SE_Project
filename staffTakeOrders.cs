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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finalsProject
{
    public partial class staffTakeOrders : Form
    {
        int orderid;
        public staffTakeOrders()
        {
            InitializeComponent();
        }
        private void staffTakeOrders_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            List<menumenu> m = new List<menumenu>();
            m = MenuDL.retrivemenuitems();
            if (m != null)
            {
                dataGridView1.DataSource = m;
                dataGridView1.Refresh();
            }

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGoldenrod;
            ShowIcon = false;
            Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            orderid = OrderDL.getorderid();
            
            if (dataGridView1.Columns["Add"].Index == e.ColumnIndex)
            {
                Form f = new Quantity();
                f.ShowDialog();
                int menuid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                int price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["price"].Value);
                int quantity = Quantity.q;
                Order o = new Order(orderid,menuid,price,quantity);
                OrderItemsDL.insertorderitem(o);
                DataTable d =  OrderItemsDL.retriveorderitem(orderid);
                dataGridView2.DataSource = d;
                dataGridView2.Refresh();
            }
        }

        private void Proceedbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Order is processed");
            Form f = new StaffMenu();
            f.Show();

        }
    }
}
