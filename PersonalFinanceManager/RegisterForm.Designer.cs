
using static System.Net.Mime.MediaTypeNames;

namespace PersonalFinanceManager;

partial class RegisterForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitle;
    private Label lblUsername;
    private Label lblEmail;
    private Label lblPassword;
    private Label lblConfirmPassword;

    private TextBox txtUsername;
    private TextBox txtEmail;
    private TextBox txtPassword;
    private TextBox txtConfirmPassword;

    private Button btnRegister;
    private Button btnBackToLogin;

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
        lblEmail = new Label();
        lblPassword = new Label();
        lblConfirmPassword = new Label();

        txtUsername = new TextBox();
        txtEmail = new TextBox();
        txtPassword = new TextBox();
        txtConfirmPassword = new TextBox();

        btnRegister = new Button();
        btnBackToLogin = new Button();

        SuspendLayout();

        // lblTitle
        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitle.Location = new Point(100, 20);
        lblTitle.Text = "Register";

        // Username
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(40, 80);
        lblUsername.Text = "Username";

        txtUsername.Location = new Point(40, 105);
        txtUsername.Size = new Size(250, 23);

        // Email
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(40, 145);
        lblEmail.Text = "Email";

        txtEmail.Location = new Point(40, 170);
        txtEmail.Size = new Size(250, 23);

        // Password
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(40, 210);
        lblPassword.Text = "Password";

        txtPassword.Location = new Point(40, 235);
        txtPassword.Size = new Size(250, 23);
        txtPassword.PasswordChar = '*';

        // Confirm Password
        lblConfirmPassword.AutoSize = true;
        lblConfirmPassword.Location = new Point(40, 275);
        lblConfirmPassword.Text = "Confirm Password";

        txtConfirmPassword.Location = new Point(40, 300);
        txtConfirmPassword.Size = new Size(250, 23);
        txtConfirmPassword.PasswordChar = '*';

        // Register
        btnRegister.Location = new Point(40, 350);
        btnRegister.Size = new Size(250, 35);
        btnRegister.Text = "Register";
        btnRegister.Click += btnRegister_Click;

        // Back
        btnBackToLogin.Location = new Point(40, 400);
        btnBackToLogin.Size = new Size(250, 35);
        btnBackToLogin.Text = "Back";
        btnBackToLogin.Click += btnBackToLogin_Click;

        // RegisterForm
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(350, 500);

        Controls.Add(lblTitle);
        Controls.Add(lblUsername);
        Controls.Add(txtUsername);
        Controls.Add(lblEmail);
        Controls.Add(txtEmail);
        Controls.Add(lblPassword);
        Controls.Add(txtPassword);
        Controls.Add(lblConfirmPassword);
        Controls.Add(txtConfirmPassword);
        Controls.Add(btnRegister);
        Controls.Add(btnBackToLogin);

        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Personal Finance Manager - Register";

        ResumeLayout(false);
        PerformLayout();
    }
}