namespace PersonalFinanceManager.UI
{
    partial class MainDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBalance = new System.Windows.Forms.Panel();
            this.lblCurrentBalanceTitle = new System.Windows.Forms.Label();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.pnlExpenses = new System.Windows.Forms.Panel();
            this.lblMonthlyExpensesTitle = new System.Windows.Forms.Label();
            this.lblMonthlyExpenses = new System.Windows.Forms.Label();
            this.pnlIncome = new System.Windows.Forms.Panel();
            this.lblMonthlyIncomeTitle = new System.Windows.Forms.Label();
            this.lblMonthlyIncome = new System.Windows.Forms.Label();
            this.pnlQuickStats = new System.Windows.Forms.Panel();
            this.chartQuickStatistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvRecentTransactions = new System.Windows.Forms.DataGridView();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpenStatistics = new System.Windows.Forms.Button();
            this.btnAddTransaction = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlBalance.SuspendLayout();
            this.pnlExpenses.SuspendLayout();
            this.pnlIncome.SuspendLayout();
            this.pnlQuickStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartQuickStatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).BeginInit();
            this.flowButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 120;
            this.pnlTop.Padding = new System.Windows.Forms.Padding(12);
            this.pnlTop.Controls.Add(this.pnlBalance);
            this.pnlTop.Controls.Add(this.pnlExpenses);
            this.pnlTop.Controls.Add(this.pnlIncome);
            this.pnlTop.Controls.Add(this.flowButtons);
            // 
            // pnlBalance
            // 
            this.pnlBalance.BackColor = System.Drawing.Color.White;
            this.pnlBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBalance.Location = new System.Drawing.Point(12, 12);
            this.pnlBalance.Size = new System.Drawing.Size(300, 96);
            this.pnlBalance.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.pnlBalance.Controls.Add(this.lblCurrentBalanceTitle);
            this.pnlBalance.Controls.Add(this.lblCurrentBalance);
            // 
            // lblCurrentBalanceTitle
            // 
            this.lblCurrentBalanceTitle.AutoSize = true;
            this.lblCurrentBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentBalanceTitle.Location = new System.Drawing.Point(12, 12);
            this.lblCurrentBalanceTitle.Text = "Current Balance";
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblCurrentBalance.Location = new System.Drawing.Point(12, 34);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(180, 37);
            this.lblCurrentBalance.Text = "$0.00";
            // 
            // pnlExpenses
            // 
            this.pnlExpenses.BackColor = System.Drawing.Color.White;
            this.pnlExpenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExpenses.Location = new System.Drawing.Point(330, 12);
            this.pnlExpenses.Size = new System.Drawing.Size(300, 96);
            this.pnlExpenses.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlExpenses.Controls.Add(this.lblMonthlyExpensesTitle);
            this.pnlExpenses.Controls.Add(this.lblMonthlyExpenses);
            // 
            // lblMonthlyExpensesTitle
            // 
            this.lblMonthlyExpensesTitle.AutoSize = true;
            this.lblMonthlyExpensesTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonthlyExpensesTitle.Location = new System.Drawing.Point(12, 12);
            this.lblMonthlyExpensesTitle.Text = "Monthly Expenses";
            // 
            // lblMonthlyExpenses
            // 
            this.lblMonthlyExpenses.AutoSize = true;
            this.lblMonthlyExpenses.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblMonthlyExpenses.Location = new System.Drawing.Point(12, 34);
            this.lblMonthlyExpenses.Name = "lblMonthlyExpenses";
            this.lblMonthlyExpenses.Size = new System.Drawing.Size(120, 30);
            this.lblMonthlyExpenses.Text = "$0.00";
            // 
            // pnlIncome
            // 
            this.pnlIncome.BackColor = System.Drawing.Color.White;
            this.pnlIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIncome.Location = new System.Drawing.Point(648, 12);
            this.pnlIncome.Size = new System.Drawing.Size(300, 96);
            this.pnlIncome.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.pnlIncome.Controls.Add(this.lblMonthlyIncomeTitle);
            this.pnlIncome.Controls.Add(this.lblMonthlyIncome);
            // 
            // lblMonthlyIncomeTitle
            // 
            this.lblMonthlyIncomeTitle.AutoSize = true;
            this.lblMonthlyIncomeTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMonthlyIncomeTitle.Location = new System.Drawing.Point(12, 12);
            this.lblMonthlyIncomeTitle.Text = "Monthly Income";
            // 
            // lblMonthlyIncome
            // 
            this.lblMonthlyIncome.AutoSize = true;
            this.lblMonthlyIncome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblMonthlyIncome.Location = new System.Drawing.Point(12, 34);
            this.lblMonthlyIncome.Name = "lblMonthlyIncome";
            this.lblMonthlyIncome.Size = new System.Drawing.Size(120, 30);
            this.lblMonthlyIncome.Text = "$0.00";
            // 
            // flowButtons
            // 
            this.flowButtons.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.flowButtons.Location = new System.Drawing.Point(964, 12);
            this.flowButtons.Size = new System.Drawing.Size(220, 96);
            this.flowButtons.Controls.Add(this.btnRefresh);
            this.flowButtons.Controls.Add(this.btnOpenStatistics);
            this.flowButtons.Controls.Add(this.btnAddTransaction);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(96, 125, 139);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Size = new System.Drawing.Size(100, 36);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpenStatistics
            // 
            this.btnOpenStatistics.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnOpenStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenStatistics.ForeColor = System.Drawing.Color.White;
            this.btnOpenStatistics.Size = new System.Drawing.Size(100, 36);
            this.btnOpenStatistics.Text = "Statistics";
            this.btnOpenStatistics.Click += new System.EventHandler(this.btnOpenStatistics_Click);
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAddTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTransaction.ForeColor = System.Drawing.Color.White;
            this.btnAddTransaction.Size = new System.Drawing.Size(100, 36);
            this.btnAddTransaction.Text = "Add";
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // pnlQuickStats
            // 
            this.pnlQuickStats.BackColor = System.Drawing.Color.White;
            this.pnlQuickStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuickStats.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlQuickStats.Width = 380;
            this.pnlQuickStats.Padding = new System.Windows.Forms.Padding(8);
            this.pnlQuickStats.Controls.Add(this.chartQuickStatistics);
            // 
            // chartQuickStatistics
            // 
            this.chartQuickStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartQuickStatistics.Name = "chartQuickStatistics";
            this.chartQuickStatistics.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            // 
            // dgvRecentTransactions
            // 
            this.dgvRecentTransactions.AllowUserToAddRows = false;
            this.dgvRecentTransactions.AllowUserToDeleteRows = false;
            this.dgvRecentTransactions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvRecentTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentTransactions.Location = new System.Drawing.Point(12, 140);
            this.dgvRecentTransactions.Name = "dgvRecentTransactions";
            this.dgvRecentTransactions.ReadOnly = true;
            this.dgvRecentTransactions.RowTemplate.Height = 28;
            this.dgvRecentTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentTransactions.Size = new System.Drawing.Size(920, 460);
            // 
            // MainDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 620);
            this.Controls.Add(this.dgvRecentTransactions);
            this.Controls.Add(this.pnlQuickStats);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "MainDashboardForm";
            this.Text = "Personal Finance Manager - Dashboard";
            this.pnlTop.ResumeLayout(false);
            this.pnlBalance.ResumeLayout(false);
            this.pnlBalance.PerformLayout();
            this.pnlExpenses.ResumeLayout(false);
            this.pnlExpenses.PerformLayout();
            this.pnlIncome.ResumeLayout(false);
            this.pnlIncome.PerformLayout();
            this.pnlQuickStats.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartQuickStatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).EndInit();
            this.flowButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBalance;
        private System.Windows.Forms.Label lblCurrentBalanceTitle;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Panel pnlExpenses;
        private System.Windows.Forms.Label lblMonthlyExpensesTitle;
        private System.Windows.Forms.Label lblMonthlyExpenses;
        private System.Windows.Forms.Panel pnlIncome;
        private System.Windows.Forms.Label lblMonthlyIncomeTitle;
        private System.Windows.Forms.Label lblMonthlyIncome;
        private System.Windows.Forms.Panel pnlQuickStats;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartQuickStatistics;
        private System.Windows.Forms.DataGridView dgvRecentTransactions;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOpenStatistics;
        private System.Windows.Forms.Button btnAddTransaction;
    }
}
