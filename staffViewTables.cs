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
    public partial class staffViewTables : Form
    {
        public staffViewTables()
        {
            InitializeComponent();
        }

        private void staffViewTables_Load(object sender, EventArgs e)
        {
            int id = SigninOthers.s.Id;
            List<Table> t =  StaffDL.staffviewassignedtables(id);
            if (t != null)
            {
                dataGridView1.DataSource = t;
                dataGridView1.Refresh();
            }
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGoldenrod;
            ShowIcon = false;
            Text = "";
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Set the background color of even rows to light gray
                e.CellStyle.BackColor = Color.PapayaWhip;
            }
            else
            {
                // Set the background color of odd rows to white
                e.CellStyle.BackColor = Color.GhostWhite;
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new StaffMenu();
            f.Show();
        }
    }
}
