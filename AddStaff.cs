using finalsProject.Classes;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace finalsProject
{
    public partial class AddStaff : Form
    {
        int id;
        int i = 0;
        public AddStaff()
        {
            InitializeComponent();
        }

        private void addDeliveryMan_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            ShowIcon = false;
            addresstxt.BackColor = Color.Khaki;
            Text = "";
            DataTable d = StaffDL.viewstaff();
            dataGridView1.DataSource = d;
        }
        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new ManagerMenu();
            f.Show();
        }

        private void addstaffbtn_Click(object sender, EventArgs e)
        {
            try
            {
                User u = new User(passwordtxt.Text, fnametxt.Text, lnametxt.Text, usertypecombo.Text, emailtxt.Text, gendercombo.Text);
                UserDL.insertUser(u);
                int id = UserDL.getuserid(emailtxt.Text);
                Staff s = new Staff(id, passwordtxt.Text, fnametxt.Text, lnametxt.Text, usertypecombo.Text, emailtxt.Text, gendercombo.Text, phonetxt.Text, addresstxt.Text, hiredateTimePicker.Value, int.Parse(salarytxt.Text));
                StaffDL.insertstaff(s);
                DataTable d = StaffDL.viewstaff();
                dataGridView1.DataSource = d;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
          
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                User u = new User(passwordtxt.Text, fnametxt.Text, lnametxt.Text, usertypecombo.Text, emailtxt.Text, gendercombo.Text);
                UserDL.updateuser(id, u);
                Staff s = new Staff(id, passwordtxt.Text, fnametxt.Text, lnametxt.Text, usertypecombo.Text, emailtxt.Text, gendercombo.Text, phonetxt.Text, addresstxt.Text, hiredateTimePicker.Value, int.Parse(salarytxt.Text));
                StaffDL.updatestaff(id, s);
                DataTable d = StaffDL.viewstaff();
                dataGridView1.DataSource = d;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns["Edit"].Index == e.ColumnIndex)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["sid"].Value);
                fnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells["first_name"].Value.ToString();
                lnametxt.Text = dataGridView1.Rows[e.RowIndex].Cells["last_name"].Value.ToString();
                emailtxt.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                passwordtxt.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
                usertypecombo.Text = dataGridView1.Rows[e.RowIndex].Cells["usertype"].Value.ToString();
                i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["gender"].Value);
                if(i == 5)
                {
                    gendercombo.Text = "male";
                }
                else if(i == 6)
                {
                    gendercombo.Text = "female";
                }
                 
                phonetxt.Text = dataGridView1.Rows[e.RowIndex].Cells["phone"].Value.ToString();
                hiredateTimePicker.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["hiredate"].Value.ToString());
                salarytxt.Text = dataGridView1.Rows[e.RowIndex].Cells["salary"].Value.ToString();
                addresstxt.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
            }
            if (dataGridView1.Columns["Delete"].Index == e.ColumnIndex)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["sid"].Value);
                assignedtaskDl.deletestafftask(id);
                OrderDL.deletestafffromorders(id);
                StaffDL.deletestaff(id);
                UserDL.deleteuser(id);
                DataTable d = StaffDL.viewstaff();
                dataGridView1.DataSource = d;


            }
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
                MessageBox.Show("Invalid Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lnametxt.BackColor = Color.White;
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
    }
}
