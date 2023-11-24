using finalsProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalsProject
{
    public partial class AddDeliveyDetails : Form
    {
        int id;
        public AddDeliveyDetails()
        {
            InitializeComponent();
        }

        private void adddeliverydetailbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DeliveryDetails d = new DeliveryDetails(signIn.c.Id, postalcodetxt.Text, deliveryAddresstxt.Text, citytxt.Text);
                DeliveryDetailsDL.insertdeliverydetails(d);
                DataTable da = DeliveryDetailsDL.viewdeliverydetails();
                dataGridView1.DataSource = da;
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
           
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DeliveryDetails d = new DeliveryDetails(signIn.c.Id, postalcodetxt.Text, deliveryAddresstxt.Text, citytxt.Text);
                DeliveryDetailsDL.updatedeliverydetails(signIn.c.Id, id, d);
                DataTable dt = DeliveryDetailsDL.viewdeliverydetails();
                dataGridView1.DataSource = dt;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns["Edit"].Index == e.ColumnIndex)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                deliveryAddresstxt.Text = dataGridView1.Rows[e.RowIndex].Cells["delivery_address"].Value.ToString();
                postalcodetxt.Text = dataGridView1.Rows[e.RowIndex].Cells["postal_code"].Value.ToString();
                citytxt.Text = dataGridView1.Rows[e.RowIndex].Cells["city"].Value.ToString();

            }
           /* if (dataGridView1.Columns["Delete"].Index == e.ColumnIndex)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                DeliveryDetailsDL.deletedeliverydetails(id);
                DataTable d = DeliveryDetailsDL.viewdeliverydetails();
                dataGridView1.DataSource = d;

            }*/
        }

        private void AddDeliveyDetails_Load(object sender, EventArgs e)
        {
            DataTable d = DeliveryDetailsDL.viewdeliverydetails();
            dataGridView1.DataSource = d;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new customerMenu();
            f.Show();
        }

        private void citytxt_Leave(object sender, EventArgs e)
        {

            Regex r = new Regex(@"^[A-Za-z]+$");
            if (r.IsMatch(citytxt.Text))
            {
                citytxt.BackColor = Color.LightSkyBlue;
            }
            else
            {

                citytxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid City Name Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                citytxt.BackColor = Color.White;
            }
        }

        private void postalcodetxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]");
            if (r.IsMatch(postalcodetxt.Text))
            {
                postalcodetxt.BackColor = Color.White;
            }
            else
            {

                postalcodetxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                postalcodetxt.BackColor = Color.White;
            }
        }
    }
}
