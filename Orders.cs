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
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox4_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]");
            if (r.IsMatch(kryptonTextBox4.Text))
            {
                kryptonTextBox4.BackColor = Color.LightSkyBlue;
            }
            else
            {

                kryptonTextBox4.BackColor = Color.LightPink;
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kryptonTextBox4.BackColor = Color.White;
            }
           
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]");
            if (r.IsMatch(kryptonTextBox1.Text))
            {
                kryptonTextBox1.BackColor = Color.LightSkyBlue;
            }
            else
            {

                kryptonTextBox1.BackColor = Color.LightPink;
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kryptonTextBox1.BackColor = Color.White;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }
    }
}
