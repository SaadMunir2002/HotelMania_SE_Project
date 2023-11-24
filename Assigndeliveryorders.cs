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
    public partial class Assigndeliveryorders : Form
    {
        List<int> ld = new List<int>();
        List<int> ls = new List<int>();
        int i;
        public Assigndeliveryorders()
        {
            InitializeComponent();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            staffidcombo.Items.Clear();
            deliveryidcombo.Items.Clear();
            this.Hide();
            Form f = new ManagerMenu();
            f.Show();
        }

        private void Assigndeliveryorders_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            ld = DeliveryDetailsDL.retrivedeliveryids();
            for (int i = 0; i < ld.Count; i++)
            {

                deliveryidcombo.Items.Add(ld[i]);
            }
            ls = StaffDL.retrivestaffids(3);
            for (int i = 0; i < ls.Count; i++)
            {

                staffidcombo.Items.Add(ls[i]);
            }
            DataTable d = assignedtaskDl.viewdeliverytask();
            dataGridView1.DataSource = d;

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (assignedtaskDl.checkdeliverymantask(int.Parse(deliveryidcombo.Text)) == true)
                {
                    AssignedTask a = new AssignedTask(int.Parse(deliveryidcombo.Text), int.Parse(staffidcombo.Text));
                    assignedtaskDl.assigndeliverytask(a);
                }
                else
                {
                    MessageBox.Show("Already Assigned");
                }
                deliveryidcombo.Items.Clear();
                ld = DeliveryDetailsDL.retrivedeliveryids();
                for (int i = 0; i < ld.Count; i++)
                {

                    deliveryidcombo.Items.Add(ld[i]);
                }
                DataTable d = assignedtaskDl.viewdeliverytask();
                dataGridView1.DataSource = d;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
           
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns["Edit"].Index == e.ColumnIndex)
            {
                i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                deliveryidcombo.Text = dataGridView1.Rows[e.RowIndex].Cells["deliveryid"].Value.ToString();
                staffidcombo.Text = dataGridView1.Rows[e.RowIndex].Cells["StaffId"].Value.ToString();

            }
            if (dataGridView1.Columns["Delete"].Index == e.ColumnIndex)
            {
                i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                assignedtaskDl.deletetask(i);
                DataTable d = assignedtaskDl.viewdeliverytask();
                dataGridView1.DataSource = d;

            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (assignedtaskDl.checkdeliverymantask(int.Parse(deliveryidcombo.Text)) == true)
                {
                    AssignedTask a = new AssignedTask(int.Parse(deliveryidcombo.Text), int.Parse(staffidcombo.Text));
                    assignedtaskDl.updatedeliverytask(i, a);
                }
                else
                {
                    MessageBox.Show("Already Assigned");
                }
                DataTable d = assignedtaskDl.viewdeliverytask();
                dataGridView1.DataSource = d;
                deliveryidcombo.Items.Clear();
                ld = DeliveryDetailsDL.retrivedeliveryids();
                for (int i = 0; i < ld.Count; i++)
                {

                    deliveryidcombo.Items.Add(ld[i]);
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
          
        }
    }
}
