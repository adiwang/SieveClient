using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieveClient
{
    public partial class WelcomeForm : Form
    {
        PrimaryForm pf = new PrimaryForm();

        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void welcomeTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                // 每单位时间增加的透明度数
                this.Opacity += 0.05;
            }
            else
            {
                this.welcomeTimer.Stop();
                System.Threading.Thread.Sleep(2000);
                this.Hide();
                pf.Show();
            }
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            this.welcomeTimer.Start();
        }
    }
}
