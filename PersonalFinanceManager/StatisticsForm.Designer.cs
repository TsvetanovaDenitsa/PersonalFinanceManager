namespace PersonalFinanceManager
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panelTop = new System.Windows.Forms.Panel();
            this.tableStats = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalBalance = new System.Windows.Forms.Label();
            this.lblMonthlyIncome = new System.Windows.Forms.Label();
            this.lblMonthlyExpenses = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chartExpenses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartExpenses)).BeginInit();
            this.panelTop.SuspendLayout();
            this.tableStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTop.Controls.Add(this.tableStats);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(12);
            this.panelTop.Size = new System.Drawing.Size(1000, 96);
            this.panelTop.TabIndex = 0;
            // 
            // tableStats
            // 
            this.tableStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableStats.ColumnCount = 3;
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableStats.Controls.Add(this.lblTotalBalance, 0, 0);
            this.tableStats.Controls.Add(this.lblMonthlyIncome, 1, 0);
            this.tableStats.Controls.Add(this.lblMonthlyExpenses, 2, 0);
            this.tableStats.Location = new System.Drawing.Point(12, 12);
            this.tableStats.Name = "tableStats";
            this.tableStats.RowCount = 1;
            this.tableStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableStats.Size = new System.Drawing.Size(860, 72);
            this.tableStats.TabIndex = 1;
            // 
            // lblTotalBalance
            // 
            this.lblTotalBalance.AutoSize = true;
            this.lblTotalBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalBalance.Location = new System.Drawing.Point(3, 0);
            this.lblTotalBalance.Name = "lblTotalBalance";
            this.lblTotalBalance.Size = new System.Drawing.Size(280, 72);
            this.lblTotalBalance.TabIndex = 0;
            this.lblTotalBalance.Text = "Total Balance: $0.00";
            this.lblTotalBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMonthlyIncome
            // 
            this.lblMonthlyIncome.AutoSize = true;
            this.lblMonthlyIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMonthlyIncome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblMonthlyIncome.Location = new System.Drawing.Point(289, 0);
            this.lblMonthlyIncome.Name = "lblMonthlyIncome";
            this.lblMonthlyIncome.Size = new System.Drawing.Size(280, 72);
            this.lblMonthlyIncome.TabIndex = 1;
            this.lblMonthlyIncome.Text = "Monthly Income: $0.00";
            this.lblMonthlyIncome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMonthlyExpenses
            // 
            this.lblMonthlyExpenses.AutoSize = true;
            this.lblMonthlyExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMonthlyExpenses.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblMonthlyExpenses.Location = new System.Drawing.Point(575, 0);
            this.lblMonthlyExpenses.Name = "lblMonthlyExpenses";
            this.lblMonthlyExpenses.Size = new System.Drawing.Size(282, 72);
            this.lblMonthlyExpenses.TabIndex = 2;
            this.lblMonthlyExpenses.Text = "Monthly Expenses: $0.00";
            this.lblMonthlyExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(888, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chartExpenses
            // 
            chartArea1.Name = "ChartArea1";
            this.chartExpenses.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartExpenses.Legends.Add(legend1);
            this.chartExpenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartExpenses.Location = new System.Drawing.Point(0, 96);
            this.chartExpenses.Name = "chartExpenses";
            this.chartExpenses.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chartExpenses.Size = new System.Drawing.Size(1000, 504);
            this.chartExpenses.TabIndex = 3;
            this.chartExpenses.Text = "Expenses by Category";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.chartExpenses);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "StatisticsForm";
            this.Text = "Finance Statistics Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.chartExpenses)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.tableStats.ResumeLayout(false);
            this.tableStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TableLayoutPanel tableStats;
        private System.Windows.Forms.Label lblTotalBalance;
        private System.Windows.Forms.Label lblMonthlyIncome;
        private System.Windows.Forms.Label lblMonthlyExpenses;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartExpenses;
    }
}
