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
using finalsProject.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace finalsProject
{
    public partial class AddFoodCategories : Form
    {
        int id;
        public AddFoodCategories()
        {
            InitializeComponent();
        }

        private void AddFoodCategories_Load(object sender, EventArgs e)
        {
            /*dataGridView1.Columns["name"].ReadOnly = true;
            dataGridView1.Columns["description"].ReadOnly = true;
            dataGridView1.Columns["id"].ReadOnly = true;*/
            DataTable d =  CategoriesDL.viewfoodcategory();
            dataGridView1.DataSource = d;
            ShowIcon = false;
            Text = "";           
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (CategoriesDL.checkcategory(nametxt.Text) == true)
                {
                    Categories c = new Categories(nametxt.Text, descriptiontxt.Text);
                    CategoriesDL.insertcategory(c);
                    DataTable d = CategoriesDL.viewfoodcategory();
                    dataGridView1.DataSource = d;
                    nametxt.Text = "";
                    descriptiontxt.Text = "";

                }
                else
                {
                    MessageBox.Show("Already Added");
                    nametxt.Text = "";
                    descriptiontxt.Text = "";
                }

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
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                nametxt.Text = dataGridView1.Rows[e.RowIndex].Cells["cname"].Value.ToString();
                descriptiontxt.Text = dataGridView1.Rows[e.RowIndex].Cells["description"].Value.ToString();

            }
            if (dataGridView1.Columns["Delete"].Index == e.ColumnIndex)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
               // OrderItemsDL.deleteorderitemsmenu(id);
                MenuDL.deletecategorymenu(id);
                CategoriesDL.deletefoodcategory(id);
                DataTable d = CategoriesDL.viewfoodcategory();
                dataGridView1.DataSource = d;

            }

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CategoriesDL.checkcategory(nametxt.Text) == true)
                {
                    Categories c = new Categories(nametxt.Text, descriptiontxt.Text);
                    CategoriesDL.updatefoodcategory(id, c);
                    DataTable d = CategoriesDL.viewfoodcategory();
                    dataGridView1.DataSource = d;
                    nametxt.Text = "";
                    descriptiontxt.Text = "";

                }
                else
                {
                    MessageBox.Show("Already Added");
                    nametxt.Text = "";
                    descriptiontxt.Text = "";
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
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
    }
}
