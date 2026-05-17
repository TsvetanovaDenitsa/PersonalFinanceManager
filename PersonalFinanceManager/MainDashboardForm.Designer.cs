namespace PersonalFinanceManager
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelTop = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            btnExport = new Button();
            btnRefresh = new Button();
            lblBalance = new Label();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblAmount = new Label();
            txtAmount = new TextBox();
            dgvTransactions = new DataGridView();
            menuStripMain = new MenuStrip();
            mnuDashboard = new ToolStripMenuItem();
            mnuStatistics = new ToolStripMenuItem();
            mnuCategories = new ToolStripMenuItem();
            mnuBudgets = new ToolStripMenuItem();
            mnuSettings = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            panelTop.SuspendLayout();
            flowButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            menuStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.WhiteSmoke;
            panelTop.Controls.Add(flowButtons);
            panelTop.Controls.Add(lblBalance);
            panelTop.Controls.Add(lblCategory);
            panelTop.Controls.Add(cmbCategory);
            panelTop.Controls.Add(lblAmount);
            panelTop.Controls.Add(txtAmount);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(12);
            panelTop.Size = new Size(1100, 106);
            panelTop.TabIndex = 0;
            // 
            // flowButtons
            // 
            flowButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowButtons.Controls.Add(btnSave);
            flowButtons.Controls.Add(btnDelete);
            flowButtons.Controls.Add(btnExport);
            flowButtons.Controls.Add(btnRefresh);
            flowButtons.Location = new Point(798, 45);
            flowButtons.Name = "flowButtons";
            flowButtons.Size = new Size(287, 48);
            flowButtons.TabIndex = 9;
            flowButtons.WrapContents = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(33, 150, 243);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(6, 3);
            btnSave.Margin = new Padding(6, 3, 6, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(60, 40);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(244, 67, 54);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(78, 3);
            btnDelete.Margin = new Padding(6, 3, 6, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(60, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(76, 175, 80);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(150, 3);
            btnExport.Margin = new Padding(6, 3, 6, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(60, 40);
            btnExport.TabIndex = 3;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(96, 125, 139);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(222, 3);
            btnRefresh.Margin = new Padding(6, 3, 6, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(60, 40);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblBalance
            // 
            lblBalance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblBalance.Location = new Point(798, 19);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(111, 20);
            lblBalance.TabIndex = 10;
            lblBalance.Text = "Balance: $0.00";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(18, 58);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(58, 15);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Category:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(100, 55);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(250, 23);
            cmbCategory.TabIndex = 5;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(18, 22);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(54, 15);
            lblAmount.TabIndex = 7;
            lblAmount.Text = "Amount:";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(100, 19);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(160, 23);
            txtAmount.TabIndex = 0;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTransactions.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTransactions.Location = new Point(12, 141);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowTemplate.Height = 28;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(1076, 497);
            dgvTransactions.TabIndex = 8;
            // 
            // menuStripMain
            // 
            menuStripMain.Items.AddRange(new ToolStripItem[] { mnuDashboard, mnuStatistics, mnuCategories, mnuBudgets, mnuSettings, mnuExit });
            menuStripMain.Location = new Point(0, 106);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1100, 24);
            menuStripMain.TabIndex = 99;
            menuStripMain.Text = "menuStripMain";
            // 
            // mnuDashboard
            // 
            mnuDashboard.Name = "mnuDashboard";
            mnuDashboard.Size = new Size(76, 20);
            mnuDashboard.Text = "Dashboard";
            mnuDashboard.Click += mnuDashboard_Click;
            // 
            // mnuStatistics
            // 
            mnuStatistics.Name = "mnuStatistics";
            mnuStatistics.Size = new Size(65, 20);
            mnuStatistics.Text = "Statistics";
            mnuStatistics.Click += mnuStatistics_Click;
            // 
            // mnuCategories
            // 
            mnuCategories.Name = "mnuCategories";
            mnuCategories.Size = new Size(75, 20);
            mnuCategories.Text = "Categories";
            mnuCategories.Click += mnuCategories_Click;
            // 
            // mnuBudgets
            // 
            mnuBudgets.Name = "mnuBudgets";
            mnuBudgets.Size = new Size(62, 20);
            mnuBudgets.Text = "Budgets";
            mnuBudgets.Click += mnuBudgets_Click;
            // 
            // mnuSettings
            // 
            mnuSettings.Name = "mnuSettings";
            mnuSettings.Size = new Size(61, 20);
            mnuSettings.Text = "Settings";
            mnuSettings.Click += mnuSettings_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(37, 20);
            mnuExit.Text = "Exit";
            mnuExit.Click += mnuExit_Click;
            // 
            // MainDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(menuStripMain);
            Controls.Add(panelTop);
            Controls.Add(dgvTransactions);
            Font = new Font("Segoe UI", 9F);
            MainMenuStrip = menuStripMain;
            MinimumSize = new Size(1000, 600);
            Name = "MainDashboardForm";
            Text = "Personal Finance Manager";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            flowButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem mnuDashboard;
        private System.Windows.Forms.ToolStripMenuItem mnuStatistics;
        private System.Windows.Forms.ToolStripMenuItem mnuCategories;
        private System.Windows.Forms.ToolStripMenuItem mnuBudgets;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}
