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
    public partial class CustomerOrder : Form
    {
       public static List<Order> ol = new List<Order>();
        public static int orderid;
        public CustomerOrder()
        {
            InitializeComponent();
        }

        private void CustomerOrder_Load(object sender, EventArgs e)
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
            if (dataGridView1.Columns["Add"].Index == e.ColumnIndex)
            {
                Form f = new Quantity();
                f.ShowDialog();
                int menuid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                int price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["price"].Value);
                string name = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                Order o1 = new Order(signIn.c.Id, menuid, price, Quantity.q);
                ol.Add(o1);
            }
        }

        private void Proceedbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new SelectDeliveryDetails();
            f.Show();
            

        }
    }
}
