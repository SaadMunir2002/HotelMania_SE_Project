using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finalsProject.Classes;


namespace finalsProject
{
    public partial class login : Form
    {
        public static bool Manager = false;
        public static bool Staff = false;
        public static bool DeliveryBoy = false;
        public static bool Customer = false;

        public login()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            Manager = false;
            Staff = false;
            DeliveryBoy = false;
            Customer = false;
            ShowIcon = false;
            Text = "";
        }

        private void managerbtn_Click(object sender, EventArgs e)
        {
            SigninOthers S = new SigninOthers();
            Manager = true;
            this.Hide();
            S.Show();
        }

        private void customerbtn_Click(object sender, EventArgs e)
        {
            signIn S = new signIn();
            Customer = true;
            this.Hide();
            S.Show();
        }

        private void staffbtn_Click(object sender, EventArgs e)
        {
            SigninOthers S = new SigninOthers();
            Staff = true;
            this.Hide();
            S.Show();
        }

        private void Deliverybtn_Click(object sender, EventArgs e)
        {
            SigninOthers S = new SigninOthers();
            DeliveryBoy = true;
            this.Hide();
            S.Show();
        }
    }
}
