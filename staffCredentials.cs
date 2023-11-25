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
    public partial class staffCredentials : Form
    {
        public staffCredentials()
        {
            InitializeComponent();
        }

        private void staffCredentials_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
            Staff s = SigninOthers.s;

            passwordtxt.Text = s.Password;
            emailtxt.Text = s.Email;
            fnametxt.Text = s.Firstname;
            lnametxt.Text = s.Lastname;
            phonetxt.Text = s.Phone;
            addresstxt.Text = s.Address;
            salarytxt.Text = s.Salary.ToString();
            hiredatetxt.Text = s.Hiredate.ToString();

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
           /* MessageBox.Show(login.Staff.ToString());
            MessageBox.Show(login.DeliveryBoy.ToString());*/
            if (login.Staff == false )
            {
                this.Hide();
                Form f = new StaffMenu();
                f.Show();
            }
            else if(login.DeliveryBoy == false)
            {
                this.Hide();
                Form f = new deliveryManMenu();
                f.Show();
            }
            
        }
        private void editbtn_Click(object sender, EventArgs e)
        {

        }

        private void fnametxt_TextChanged(object sender, EventArgs e)
        {

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

        private void phonetxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"03[0-9]{9}$");
            if (r.IsMatch(phonetxt.Text))
            {
                phonetxt.BackColor = Color.LightSkyBlue;
            }
            else
            {

                phonetxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid Phone Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phonetxt.BackColor = Color.White;
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

        private void salarytxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]");
            if (r.IsMatch(salarytxt.Text))
            {
                salarytxt.BackColor = Color.White;
            }
            else
            {

                salarytxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                salarytxt.BackColor = Color.White;
            }
        }
    }
}
