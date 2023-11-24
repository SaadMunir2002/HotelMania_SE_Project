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
    public partial class AssignTableToStaff : Form
    {
        List<int> lt = new List<int>();
        List<int>  ls = new List<int>();
        int i;
        public AssignTableToStaff()
        {
            InitializeComponent();
        }

        private void AssignTableToStaff_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
            lt = TableDL.retrivetableids();
            for (int i = 0; i < lt.Count; i++)
            {

                tableidcombo.Items.Add(lt[i]);
            }
            ls = StaffDL.retrivestaffids(2);
            for (int i = 0; i < ls.Count; i++)
            {

                staffidcombo.Items.Add(ls[i]);
            }
            DataTable d = assignedtaskDl.viewstafftask();
            dataGridView1.DataSource = d;

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            staffidcombo.Items.Clear();
            tableidcombo.Items.Clear();
            this.Hide();
            Form f = new ManagerMenu();
            f.Show();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (assignedtaskDl.checkwaitertask(int.Parse(tableidcombo.Text)) == true)
                {
                    AssignedTask a = new AssignedTask(int.Parse(tableidcombo.Text), int.Parse(staffidcombo.Text));
                    assignedtaskDl.assigntask(a);
                }
                else
                {
                    MessageBox.Show("Already Assigned");
                }
                DataTable d = assignedtaskDl.viewstafftask();
                dataGridView1.DataSource = d;
                tableidcombo.Items.Clear();
                lt = TableDL.retrivetableids();
                for (int i = 0; i < lt.Count; i++)
                {

                    tableidcombo.Items.Add(lt[i]);
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
           
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                AssignedTask a = new AssignedTask(int.Parse(tableidcombo.Text), int.Parse(staffidcombo.Text));
                assignedtaskDl.updatetask(i, a);
                DataTable d = assignedtaskDl.viewstafftask();
                dataGridView1.DataSource = d;
                tableidcombo.Items.Clear();
                lt = TableDL.retrivetableids();
                for (int i = 0; i < lt.Count; i++)
                {

                    tableidcombo.Items.Add(lt[i]);
                }
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
                tableidcombo.Text = dataGridView1.Rows[e.RowIndex].Cells["table_id"].Value.ToString();
                staffidcombo.Text = dataGridView1.Rows[e.RowIndex].Cells["staff_id"].Value.ToString();

            }
            if (dataGridView1.Columns["Delete"].Index == e.ColumnIndex)
            {
                i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                assignedtaskDl.deletetask(i);
                DataTable d = assignedtaskDl.viewstafftask();
                dataGridView1.DataSource = d;

            }
        }
    }
}
