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
    public partial class signIn : Form
    {
       public static Customer c;
        public signIn()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new login();
            f.Show();
        }
        private void signinbtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                //after matching credentials from db
                login.DeliveryBoy = false;
                login.Staff = false;
                login.Manager = false;
                if (CustomerDL.signinvalidcustomer(emailtxt.Text, passwordtxt.Text, 1) == true)
                {
                    c = CustomerDL.customerinfo(emailtxt.Text, 1);
                    customerMenu C = new customerMenu();
                    C.Show();
                }
                else
                {
                    MessageBox.Show("Invalid email or password");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
          
        }
        private void signupbtn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            signUp S = new signUp();
            S.Show();
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
    }
}
