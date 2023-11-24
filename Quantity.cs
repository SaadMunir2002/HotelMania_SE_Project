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
    public partial class Quantity : Form
    {
        static public int q;
        public Quantity()
        {
            InitializeComponent();
        }

        private void Proceedbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (quantitytxt.Text != "")
                {
                    q = int.Parse(quantitytxt.Text);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("enter quantity");
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
         

        }

        private void Quantity_Load(object sender, EventArgs e)
        {

        }

        private void quantitytxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]");
            if (r.IsMatch(quantitytxt.Text))
            {
                quantitytxt.BackColor = Color.LightSkyBlue;
            }
            else
            {

                quantitytxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantitytxt.BackColor = Color.White;
            }
        }
    }
}
