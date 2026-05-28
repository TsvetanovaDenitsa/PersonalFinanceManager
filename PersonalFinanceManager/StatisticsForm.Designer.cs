// StatisticsForm.Designer.cs

using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalFinanceManager
{
    partial class StatisticsForm
    {
        private System.ComponentModel
            .IContainer components = null;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            chartExpenses =
                new System.Windows.Forms
                .DataVisualization
                .Charting.Chart();

            lblTitle = new Label();

            lblIncome = new Label();

            lblExpenses = new Label();

            lblBalance = new Label();

            lblTransactions =
                new Label();

            btnClose = new Button();

            ((System.ComponentModel
                .ISupportInitialize)
                chartExpenses)
                .BeginInit();

            SuspendLayout();

            // chartExpenses

            chartExpenses.Location =
                new Point(30, 80);

            chartExpenses.Name =
                "chartExpenses";

            chartExpenses.Size =
                new Size(500, 320);

            chartExpenses.TabIndex = 0;

            ChartArea chartArea =
                new ChartArea();

            chartExpenses.ChartAreas
                .Add(chartArea);

            // lblTitle

            lblTitle.AutoSize = true;

            lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    20F,
                    FontStyle.Bold);

            lblTitle.Location =
                new Point(180, 20);

            lblTitle.Text =
                "Statistics Dashboard";

            // lblIncome

            lblIncome.AutoSize = true;

            lblIncome.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblIncome.Location =
                new Point(580, 100);

            lblIncome.Text =
                "Total Income: $0.00";

            // lblExpenses

            lblExpenses.AutoSize = true;

            lblExpenses.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblExpenses.Location =
                new Point(580, 150);

            lblExpenses.Text =
                "Total Expenses: $0.00";

            // lblBalance

            lblBalance.AutoSize = true;

            lblBalance.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblBalance.Location =
                new Point(580, 200);

            lblBalance.Text =
                "Current Balance: $0.00";

            // lblTransactions

            lblTransactions.AutoSize =
                true;

            lblTransactions.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            lblTransactions.Location =
                new Point(580, 250);

            lblTransactions.Text =
                "Transactions: 0";

            // btnClose

            btnClose.Location =
                new Point(620, 340);

            btnClose.Size =
                new Size(140, 40);

            btnClose.Text =
                "Close";

            btnClose.Click +=
                btnClose_Click;

            // StatisticsForm

            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(850, 450);

            Controls.Add(
                chartExpenses);

            Controls.Add(
                lblTitle);

            Controls.Add(
                lblIncome);

            Controls.Add(
                lblExpenses);

            Controls.Add(
                lblBalance);

            Controls.Add(
                lblTransactions);

            Controls.Add(
                btnClose);

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox = false;

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "Statistics Dashboard";

            ((System.ComponentModel
                .ISupportInitialize)
                chartExpenses)
                .EndInit();

            ResumeLayout(false);

            PerformLayout();
        }

        #endregion

        private System.Windows.Forms
            .DataVisualization
            .Charting.Chart
            chartExpenses;

        private Label lblTitle;

        private Label lblIncome;

        private Label lblExpenses;

        private Label lblBalance;

        private Label lblTransactions;

        private Button btnClose;
    }
}