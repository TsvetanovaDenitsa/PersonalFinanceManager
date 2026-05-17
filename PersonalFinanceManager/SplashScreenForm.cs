using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFinanceManager
{

    public partial class SplashScreenForm : Form
    {
        private System.Windows.Forms.Timer timer;

        public SplashScreenForm()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();

            timer.Interval = 3000;

            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();

            LoginForm loginForm = new LoginForm();

            Hide();

            loginForm.ShowDialog();

            Close();
        }
    }
}
