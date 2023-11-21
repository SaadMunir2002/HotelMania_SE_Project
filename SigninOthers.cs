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
    public partial class SigninOthers : Form
    {
        public static Staff s;
        public SigninOthers()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new login();
            f.Show();
        }
        private void signInbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (login.Manager == true)
                {
                    //match credentials here from db
                    if (StaffDL.signinvalidstaff(emailtxt.Text, passwordtxt.Text, 4) == true)
                    {
                        login.Manager = false;
                        this.Hide();
                        ManagerMenu M = new ManagerMenu();
                        M.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password");
                        login.Manager = true;
                    }
                    //after matchin them open menus accordingly

                }
                if (login.DeliveryBoy == true)
                {

                    if (StaffDL.signinvalidstaff(emailtxt.Text, passwordtxt.Text, 3) == true)
                    {
                        login.DeliveryBoy = false;
                        login.Staff = true;
                        this.Hide();
                        s = StaffDL.staffinfo(emailtxt.Text, 3);
                        deliveryManMenu D = new deliveryManMenu();
                        D.Show();
                    }
                    else
                    {
                      
                        login.DeliveryBoy = true;
                    }

                }
                if (login.Staff == true)
                {

                    if (StaffDL.signinvalidstaff(emailtxt.Text, passwordtxt.Text, 2) == true)
                    {
                        login.Staff = false;
                        login.DeliveryBoy = true;
                        this.Hide();
                        s = StaffDL.staffinfo(emailtxt.Text, 2);
                        StaffMenu S = new StaffMenu();
                        S.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password");
                        login.Staff = true;
                    }

                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
