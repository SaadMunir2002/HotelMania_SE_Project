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
    public partial class CustomerViewOrder : Form
    {
        public CustomerViewOrder()
        {
            InitializeComponent();
        }

        private void CustomerViewOrder_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            Text = "";
        }
    }
}
