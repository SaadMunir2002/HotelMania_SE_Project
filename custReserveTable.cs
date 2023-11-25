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
    public partial class custReserveTable : Form
    {
        List<int> lt = new List<int>();
        public custReserveTable()
        {
            InitializeComponent();
        }

        private void custReserveTable_Load(object sender, EventArgs e)
        {
            /* ShowIcon = false;
             Text = "";
             Reservation R = new Reservation(dateTimePicker1.Value);*/
            tableidcombo.Items.Clear();
            Customer c = signIn.c;
            lt = TableDL.retrivetableids();
            for (int i = 0; i < lt.Count; i++)
            {

                tableidcombo.Items.Add(lt[i]);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (kryptonDateTimePicker2.Value != null && tableidcombo.Text != "")
                {
                    Reservation R = new Reservation(kryptonDateTimePicker2.Value);
                    Customer c = signIn.c;
                    R.Custid = c.Id;
                    R.Tableid = int.Parse(tableidcombo.Text);
                    R.Status = 1;
                    ReservationDL.insertTable(R);
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
          
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
          //  staffidcombo.Items.Clear();
            tableidcombo.Items.Clear();
            this.Hide();
            Form f = new customerMenu();
            f.Show();
        }
    }
}
