using PersonalFinanceManager.BLL;
using PersonalFinanceManager.UI;
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
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        public LoginForm()
        {
            InitializeComponent();

            _userService = new UserService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter username and password.");
                    return;
                }

                bool isValid = _userService.LoginUser(username, password);

                if (isValid)
                {
                    MainDashboardForm dashboard = new MainDashboardForm();

                    Hide();

                    dashboard.ShowDialog();

                    Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpenRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();

            Hide();

            registerForm.ShowDialog();

            Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}