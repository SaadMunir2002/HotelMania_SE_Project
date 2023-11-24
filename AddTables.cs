using finalsProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalsProject
{
    public partial class AddTables : Form
    {
        int id;
        public AddTables()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddTables_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            ShowIcon = false;
            Text = "";
            DataTable d = TableDL.viewtable();
            dataGridView1.DataSource = d;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int tn = int.Parse(tablenumbertxt.Text);
                int f = int.Parse(floornotxt.Text);
                if (TableDL.checktable(tn, f) == true)
                {
                    Table t = new Table(tn, f);
                    TableDL.inserttable(t);
                }
                else
                {
                    MessageBox.Show("Already Added");
                }
                DataTable d = TableDL.viewtable();
                dataGridView1.DataSource = d;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
         
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new ManagerMenu();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns["Edit"].Index == e.ColumnIndex)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["tid"].Value);
                tablenumbertxt.Text = dataGridView1.Rows[e.RowIndex].Cells["table_no"].Value.ToString();
                floornotxt.Text = dataGridView1.Rows[e.RowIndex].Cells["floor"].Value.ToString();
                
            }
            if (dataGridView1.Columns["Delete"].Index == e.ColumnIndex)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["tid"].Value);
                assignedtaskDl.deletetabletask(id);
                TableDL.deletetable(id);
                DataTable d = TableDL.viewtable();
                dataGridView1.DataSource = d;

            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int tn = int.Parse(tablenumbertxt.Text);
                int f = int.Parse(floornotxt.Text);
                if (TableDL.checktable(tn, f) == true)
                {
                    Table t = new Table(tn, f);
                    TableDL.updatetable(id, t);
                }
                else
                {
                    MessageBox.Show("Already Added");
                }
                DataTable d = TableDL.viewtable();
                dataGridView1.DataSource = d;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
          
        }

        private void floornotxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]");
            if (r.IsMatch(floornotxt.Text))
            {
                floornotxt.BackColor = Color.White;
            }
            else
            {

                floornotxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                floornotxt.BackColor = Color.White;
            }
        }

        private void tablenumbertxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]");
            if (r.IsMatch(tablenumbertxt.Text))
            {
                tablenumbertxt.BackColor = Color.White;
            }
            else
            {

                tablenumbertxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tablenumbertxt.BackColor = Color.White;
            }
        }
    }
}
