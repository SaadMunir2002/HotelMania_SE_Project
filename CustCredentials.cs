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


namespace finalsProject
{
    public partial class CustCredentials : Form
    {
        public CustCredentials()
        {
            InitializeComponent();
        }

        private void CustCredentials_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = ""; 
            Customer c = signIn.c;

            idtxt.Text = c.Id.ToString();
            passwordtxt.Text = c.Password;
            emailtxt.Text = c.Email;
            fnametxt.Text = c.Firstname;
            lnametxt.Text = c.Lastname;
            phoneNotxt.Text = c.Phone;
            addresstxt.Text = c.Address;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new customerMenu();
            f.Show();
        }

        private void editbtn_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new customerMenu();
            f.Show();
        }


        private void fnametxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[A-Za-z]+$");
            if (r.IsMatch(fnametxt.Text))
            {
                fnametxt.BackColor = Color.LightSkyBlue;
            }
            else
            {

                fnametxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid Name Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fnametxt.BackColor = Color.White;
            }
           
        }

        private void lnametxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[A-Za-z]+$");
            if (r.IsMatch(lnametxt.Text))
            {
                lnametxt.BackColor = Color.LightSkyBlue;
            }
            else
            {

                lnametxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid Name Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lnametxt.BackColor = Color.White;
            }
        }

        private void emailtxt_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-z]{2,9})$";

            if (Regex.IsMatch(emailtxt.Text, pattern) == false)
            {

                emailtxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailtxt.BackColor = Color.White;
            }
            else
            {

                emailtxt.BackColor = Color.White;
            }
        }

        private void phoneNotxt_Leave(object sender, EventArgs e)
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

        private void passwordtxt_Leave(object sender, EventArgs e)
        {
         
            Regex r = new Regex(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
            if (r.IsMatch(passwordtxt.Text) == false)
            {

                passwordtxt.BackColor = Color.LightPink;
                MessageBox.Show("Password must contains at least eight characters, including at least one number and includes both lower and uppercase letters and special characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordtxt.BackColor = Color.White;
            }
            else
            {

                passwordtxt.BackColor = Color.White;
            }

        }

        private void fnametxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
