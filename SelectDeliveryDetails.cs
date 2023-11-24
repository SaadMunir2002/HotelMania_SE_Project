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
    public partial class SelectDeliveryDetails : Form
    {
        List<int> l = new List<int>();
        public static int orderid;
        public SelectDeliveryDetails()
        {
            InitializeComponent();
        }

        private void SelectDeliveryDetails_Load(object sender, EventArgs e)
        {
            deliveryidcombo.Items.Clear();
            l = DeliveryDetailsDL.selectdeliveryids(signIn.c.Id);
            for(int i = 0; i <l.Count; i++)
            {
                deliveryidcombo.Items.Add(l[i]);
            }
        }

        private void Proceedbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Order o = new Order(signIn.c.Id, int.Parse(deliveryidcombo.Text));
                OrderDL.customerorder(o);
                orderid = OrderDL.getorderid();
                MessageBox.Show(orderid.ToString());
                for (int i = 0; i < CustomerOrder.ol.Count; i++)
                {
                    Order o2 = new Order(orderid, CustomerOrder.ol[i].Menuid, CustomerOrder.ol[i].Price, CustomerOrder.ol[i].Quantity);
                    OrderItemsDL.insertorderitem(o2);
                }
                MessageBox.Show("Items are added to cart");
                deliveryidcombo.Items.Clear();
                this.Hide();
                Form f = new customerMenu();
                f.Show();

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
          
        }
    }
}
