
using static System.Net.Mime.MediaTypeNames;

namespace PersonalFinanceManager;

partial class SplashScreenForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitle;
    private Label lblSubtitle;
    private ProgressBar progressBar;

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
        lblSubtitle = new Label();
        progressBar = new ProgressBar();

        SuspendLayout();

        // lblTitle
        lblTitle.AutoSize = true;
        lblTitle.Font = new System.Drawing.Font(
            "Segoe UI",
            24F,
            FontStyle.Bold);

        lblTitle.Location = new Point(70, 60);

        lblTitle.Text =
            "Personal Finance Manager";

        // lblSubtitle
        lblSubtitle.AutoSize = true;

        lblSubtitle.Font = new System.Drawing.Font(
            "Segoe UI",
            12F,
            FontStyle.Regular);

        lblSubtitle.Location = new Point(140, 130);

        lblSubtitle.Text =
            "Loading application...";

        // progressBar
        progressBar.Location =
            new Point(50, 220);

        progressBar.Size =
            new Size(420, 25);

        progressBar.Style =
            ProgressBarStyle.Marquee;

        // SplashScreenForm
        AutoScaleDimensions =
            new SizeF(7F, 15F);

        AutoScaleMode =
            AutoScaleMode.Font;

        BackColor = Color.White;

        ClientSize =
            new Size(520, 320);

        Controls.Add(lblTitle);
        Controls.Add(lblSubtitle);
        Controls.Add(progressBar);

        FormBorderStyle =
            FormBorderStyle.None;

        StartPosition =
            FormStartPosition.CenterScreen;

        Text = "SplashScreen";

        ResumeLayout(false);

        PerformLayout();
    }
}