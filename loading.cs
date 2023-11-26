using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalsProject
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        int startpoint = 0;

        private void loadingTimer_Tick(object sender, EventArgs e)
        {
            startpoint = startpoint + 10;
            progressBar1.Value = startpoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;

                loadingTimer.Stop();
                login form = new login();
                this.Hide();
                form.Show();



            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadingTimer.Start();
            loading L = new loading();
            L.Show();
        }
    }
}
