using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using finalsProject.Classes;


namespace finalsProject
{
    public partial class deliveryCredntials : Form
    {
        public deliveryCredntials()
        {
            InitializeComponent();
        }

        private void deliveryCredntials_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"03[0-9]{9}$");
            if (r.IsMatch(phoneNotxt.Text))
            {
                phoneNotxt.BackColor = Color.LightSkyBlue;
            }
            else
            {

                phoneNotxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid Phone Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phoneNotxt.BackColor = Color.White;
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {

            Regex r = new Regex(@"^[0-9]");
            if (r.IsMatch(kryptonTextBox2.Text))
            {
                kryptonTextBox2.BackColor = Color.White;
            }
            else
            {

                kryptonTextBox2.BackColor = Color.LightPink;
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kryptonTextBox2.BackColor = Color.White;
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
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
