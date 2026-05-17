
// TransactionForm.Designer.cs

using static System.Net.Mime.MediaTypeNames;

namespace PersonalFinanceManager
{
    partial class TransactionForm
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
            lblTitle = new Label();
            lblAmount = new Label();
            txtAmount = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblType = new Label();
            cmbTransactionType = new ComboBox();
            lblDate = new Label();
            dtpTransactionDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            // lblTitle

            lblTitle.AutoSize = true;

            lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            lblTitle.Location =
                new Point(90, 20);

            lblTitle.Text =
                "Add Transaction";

            // lblAmount

            lblAmount.AutoSize = true;

            lblAmount.Location =
                new Point(30, 90);

            lblAmount.Text =
                "Amount";

            // txtAmount

            txtAmount.Location =
                new Point(150, 87);

            txtAmount.Size =
                new Size(200, 23);

            // lblDescription

            lblDescription.AutoSize = true;

            lblDescription.Location =
                new Point(30, 140);

            lblDescription.Text =
                "Description";

            // txtDescription

            txtDescription.Location =
                new Point(150, 137);

            txtDescription.Size =
                new Size(200, 23);

            // lblCategory

            lblCategory.AutoSize = true;

            lblCategory.Location =
                new Point(30, 190);

            lblCategory.Text =
                "Category";

            // cmbCategory

            cmbCategory.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbCategory.Location =
                new Point(150, 187);

            cmbCategory.Size =
                new Size(200, 23);

            // lblType

            lblType.AutoSize = true;

            lblType.Location =
                new Point(30, 240);

            lblType.Text =
                "Type";

            // cmbTransactionType

            cmbTransactionType
                .DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbTransactionType.Location =
                new Point(150, 237);

            cmbTransactionType.Size =
                new Size(200, 23);

            // lblDate

            lblDate.AutoSize = true;

            lblDate.Location =
                new Point(30, 290);

            lblDate.Text =
                "Date";

            // dtpTransactionDate

            dtpTransactionDate.Location =
                new Point(150, 287);

            dtpTransactionDate.Size =
                new Size(200, 23);

            // btnSave

            btnSave.Location =
                new Point(70, 360);

            btnSave.Size =
                new Size(120, 40);

            btnSave.Text =
                "Save";

            btnSave.Click +=
                btnSave_Click;

            // btnCancel

            btnCancel.Location =
                new Point(220, 360);

            btnCancel.Size =
                new Size(120, 40);

            btnCancel.Text =
                "Cancel";

            btnCancel.Click +=
                btnCancel_Click;

            // TransactionForm

            AutoScaleDimensions =
                new SizeF(7F, 15F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(400, 450);

            Controls.Add(lblTitle);

            Controls.Add(lblAmount);

            Controls.Add(txtAmount);

            Controls.Add(lblDescription);

            Controls.Add(txtDescription);

            Controls.Add(lblCategory);

            Controls.Add(cmbCategory);

            Controls.Add(lblType);

            Controls.Add(cmbTransactionType);

            Controls.Add(lblDate);

            Controls.Add(dtpTransactionDate);

            Controls.Add(btnSave);

            Controls.Add(btnCancel);

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox =
                false;

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "Transaction";

            ResumeLayout(false);

            PerformLayout();
        }

        #endregion

        private Label lblTitle;

        private Label lblAmount;

        private TextBox txtAmount;

        private Label lblDescription;

        private TextBox txtDescription;

        private Label lblCategory;

        private ComboBox cmbCategory;

        private Label lblType;

        private ComboBox cmbTransactionType;

        private Label lblDate;

        private DateTimePicker
            dtpTransactionDate;

        private Button btnSave;

        private Button btnCancel;
    }
}