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
    public partial class BillGeneration : Form
    {
        List<int> l = new List<int>();
        public BillGeneration()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BillGeneration_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
            orderidcombo.Items.Clear();
            l = OrderDL.retriveorderids();
            for (int i = 0; i < l.Count; i++)
            {

                orderidcombo.Items.Add(l[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (orderidcombo.Text != "")
                {
                    // dataGridView1.AutoGenerateColumns = false;
                    DataTable d = OrderItemsDL.retriveorderitem(int.Parse(orderidcombo.Text));
                    dataGridView1.DataSource = d;
                    int bill = OrderItemsDL.generatecustbill(int.Parse(orderidcombo.Text));
                    label5.Text = bill.ToString();
                    
                }
                else
                {
                    MessageBox.Show("select orderid");
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
          
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form f = new ManagerMenu();
            f.Show();
        }
        Bitmap bitmap;
        private void printbtn_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
           
        }

      
        private void printPreviewDialog1_Load_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void document(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(amountpaidtxt.Text != "")
            {
                int a = int.Parse(amountpaidtxt.Text);
                int b = Convert.ToInt32(label5.Text);
                if (a >= b)
                {
                    int c = -(Convert.ToInt32(label5.Text) - int.Parse(amountpaidtxt.Text));
                    label1.Text = c + " Rs";
                }
                else
                {
                    MessageBox.Show("amount Paid not added correctly");
                }
            }
            else
            {
                MessageBox.Show(" Add amount to be Paid ");
            }
            
           
        }
    }
}
