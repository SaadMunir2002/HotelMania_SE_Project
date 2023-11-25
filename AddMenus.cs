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
    public partial class AddMenus : Form
    {
        static List<string> l = new List<string>();
        int id;
        public AddMenus()
        {
            InitializeComponent();
        }

        private void AddMenu_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
            l= CategoriesDL.retrivecategory();
            for (int i = 0; i < l.Count; i++)
            {

                categorycombo.Items.Add(l[i]);
            }
            DataTable d = MenuDL.viewmenu();
            dataGridView1.DataSource = d;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            categorycombo.Items.Clear();
            this.Hide();
            Form f = new ManagerMenu();
            f.Show();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MenuDL.checkmenuitem(nametxt.Text, categorycombo.Text) == true)
                {
                    menumenu m = new menumenu(categorycombo.Text, nametxt.Text, descriptiontxt.Text, decimal.Parse(pricetxt.Text));
                    MenuDL.insertmenuitem(m);
                    DataTable ad = MenuDL.viewmenu();
                    dataGridView1.DataSource = ad;
                }
                else
                {
                    MessageBox.Show("Already Added");
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
                menumenu m = new menumenu(categorycombo.Text, nametxt.Text, descriptiontxt.Text, decimal.Parse(pricetxt.Text));
                MenuDL.updatemenu(id, m);
                DataTable d = MenuDL.viewmenu();
                dataGridView1.DataSource = d;
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
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["mid"].Value);
                nametxt.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                descriptiontxt.Text = dataGridView1.Rows[e.RowIndex].Cells["description"].Value.ToString();
                categorycombo.Text = dataGridView1.Rows[e.RowIndex].Cells["cname"].Value.ToString();
                pricetxt.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString();
            }
            if (dataGridView1.Columns["Delete"].Index == e.ColumnIndex)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["mid"].Value);
                MenuDL.deletemenu(id);
                DataTable d = MenuDL.viewmenu();
                dataGridView1.DataSource = d;

            }
        }

        private void nametxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[A-Za-z]+$");
            if (r.IsMatch(nametxt.Text))
            {
                nametxt.BackColor = Color.LightSkyBlue;
            }
            else
            {

                nametxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nametxt.BackColor = Color.White;
            }
        }

        private void descriptiontxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^([A-Za-z]*)?$");
            if (r.IsMatch(descriptiontxt.Text))
            {
                descriptiontxt.BackColor = Color.LightSkyBlue;
            }
            else
            {

                descriptiontxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                descriptiontxt.BackColor = Color.White;
            }
        }

        private void pricetxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]");
            if (r.IsMatch(pricetxt.Text))
            {
                pricetxt.BackColor = Color.White;
            }
            else
            {

                pricetxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pricetxt.BackColor = Color.White;
            }
        }
    }
}
