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
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }

        private void signUp_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";


        }

        private void signupbtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (firstNametxt.Text != "" && passwordtxt.Text != "" && usertypecombo.Text != "" && emailtxt.Text != "" && Gendercombo.Text != "")
                {
                    if (UserDL.checkemail(emailtxt.Text) == true)
                    {
                        User U = new User(passwordtxt.Text, firstNametxt.Text, lastNametxt.Text, usertypecombo.Text, emailtxt.Text, Gendercombo.Text);
                        UserDL.insertUser(U);
                        int id = UserDL.getuserid(U.Email);
                        Customer c = new Customer(id, U.Password, U.Firstname, U.Lastname, U.Usertype, U.Email, U.Gender, phonetxt.Text, addresstxt.Text);
                        CustomerDL.insertcustomer(c);
                        // after creating account 
                        MessageBox.Show("Your Account Has Been created Successfully");
                        this.Hide();
                        //then open signin form again
                        signIn S = new signIn();
                        S.Show();
                    }
                    else
                    {
                        MessageBox.Show("email already exist");
                    }

                }
                else
                {
                    MessageBox.Show("Enter Proper Information to make Account Successfully");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backbtn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new signIn();
            f.Show();
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
                phonetxt.BackColor = Color.White;
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

        private void firstNametxt_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void firstNametxt_Leave(object sender, EventArgs e)
        {

            Regex r = new Regex(@"^[A-Za-z]+$");
            if (r.IsMatch(firstNametxt.Text))
            {
                firstNametxt.BackColor = Color.White;
            }
            else
            {

                firstNametxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid Name Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                firstNametxt.BackColor = Color.White;
            }
        }

        private void lastNametxt_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[A-Za-z]+$");
            if (r.IsMatch(lastNametxt.Text))
            {
                lastNametxt.BackColor = Color.White;
            }
            else
            {

                lastNametxt.BackColor = Color.LightPink;
                MessageBox.Show("Invalid Name Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lastNametxt.BackColor = Color.White;
            }
        }
    }
}
