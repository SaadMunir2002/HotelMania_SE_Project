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
    public partial class StaffChooseTable : Form
    {
        int staffid = SigninOthers.s.Id;
        static public int orderid;
        public StaffChooseTable()
        {
            InitializeComponent();
        }

        private void StaffChooseTable_Load(object sender, EventArgs e)
        {
            tableidcombo.Items.Clear();
            List<int> l =  StaffDL.viewassignedtables(staffid);
            for(int i = 0; i <l.Count; i++)
            {
                tableidcombo.Items.Add(l[i]);
            }
        }
        private void Proceedbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Order o = new Order(staffid, int.Parse(tableidcombo.Text));
                OrderDL.StaffChooseTable(o);
                orderid = o.Orderid;
                this.Hide();
                Form f = new staffTakeOrders();
                f.Show();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
          
        }

        private void backbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
