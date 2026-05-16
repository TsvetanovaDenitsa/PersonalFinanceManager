namespace PersonalFinanceManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Amount = new Label();
            txtAmount = new TextBox();
            cmbCategory = new ComboBox();
            btnSave = new Button();
            dgvTransactions = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // Amount
            // 
            Amount.AutoSize = true;
            Amount.Location = new Point(21, 31);
            Amount.Name = "Amount";
            Amount.Size = new Size(51, 15);
            Amount.TabIndex = 0;
            Amount.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(93, 28);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(211, 23);
            txtAmount.TabIndex = 1;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] { "All", "Food", "Transport", "Bills", "Salary", "Entertainment" });
            cmbCategory.Location = new Point(25, 97);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(279, 23);
            cmbCategory.TabIndex = 2;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(120, 147);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete = new Button();
            btnDelete.Location = new Point(210, 147);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExport
            // 
            btnExport = new Button();
            btnExport.Location = new Point(30, 147);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 23);
            btnExport.TabIndex = 4;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // lblBalance
            // 
            lblBalance = new Label();
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(21, 60);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(80, 15);
            lblBalance.TabIndex = 6;
            lblBalance.Text = "Balance: $0.00";

            // 
            // dgvTransactions
            // 
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(21, 207);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.Size = new Size(291, 231);
            dgvTransactions.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 450);
            Controls.Add(dgvTransactions);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnExport);
            Controls.Add(lblBalance);
            Controls.Add(cmbCategory);
            Controls.Add(txtAmount);
            Controls.Add(Amount);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Amount;
        private TextBox txtAmount;
        private ComboBox cmbCategory;
        private Button btnSave;
        private Button btnDelete;
        private Label lblBalance;
        private Button btnExport;
        private DataGridView dgvTransactions;
    }
}
