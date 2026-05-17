
using static System.Net.Mime.MediaTypeNames;

namespace PersonalFinanceManager;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitle;
    private Label lblUsername;
    private Label lblPassword;

    private TextBox txtUsername;
    private TextBox txtPassword;

    private Button btnLogin;
    private Button btnOpenRegister;
    private Button btnExit;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblUsername = new Label();
        lblPassword = new Label();

        txtUsername = new TextBox();
        txtPassword = new TextBox();

        btnLogin = new Button();
        btnOpenRegister = new Button();
        btnExit = new Button();

        SuspendLayout();

        // lblTitle
        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.Location = new Point(120, 30);
        lblTitle.Text = "Login";

        // lblUsername
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(50, 100);
        lblUsername.Text = "Username";

        // txtUsername
        txtUsername.Location = new Point(50, 125);
        txtUsername.Size = new Size(250, 23);

        // lblPassword
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(50, 170);
        lblPassword.Text = "Password";

        // txtPassword
        txtPassword.Location = new Point(50, 195);
        txtPassword.Size = new Size(250, 23);
        txtPassword.PasswordChar = '*';

        // btnLogin
        btnLogin.Location = new Point(50, 250);
        btnLogin.Size = new Size(250, 35);
        btnLogin.Text = "Login";
        btnLogin.Click += btnLogin_Click;

        // btnOpenRegister
        btnOpenRegister.Location = new Point(50, 300);
        btnOpenRegister.Size = new Size(250, 35);
        btnOpenRegister.Text = "Register";
        btnOpenRegister.Click += btnOpenRegister_Click;

        // btnExit
        btnExit.Location = new Point(50, 350);
        btnExit.Size = new Size(250, 35);
        btnExit.Text = "Exit";
        btnExit.Click += btnExit_Click;

        // LoginForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(360, 450);
        Controls.Add(lblTitle);
        Controls.Add(lblUsername);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(txtPassword);
        Controls.Add(btnLogin);
        Controls.Add(btnOpenRegister);
        Controls.Add(btnExit);

        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Personal Finance Manager - Login";

        ResumeLayout(false);
        PerformLayout();
    }
}