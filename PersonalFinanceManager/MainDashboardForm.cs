using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager
{
    public partial class MainDashboardForm : Form
    {
        private readonly TransactionRepository _txRepo;
        private readonly CategoryRepository _catRepo;

        private List<Transaction> _transactions = new();
        private List<Category> _categories = new();

        public MainDashboardForm()
        {
            InitializeComponent();

            var db = new DatabaseManager();
            _txRepo = new TransactionRepository(db);
            _catRepo = new CategoryRepository(db);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                lblWelcome.Text = $"Welcome, {CurrentUser.Username}";
                LoadCategories();
                LoadTransactions();
                CalculateBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            _categories = _catRepo.GetAllCategories() ?? new List<Category>();

            cmbCategory.BeginUpdate();
            try
            {
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
                cmbCategory.Items.Clear();

                cmbCategory.Items.Add(new Category { Id = 0, Name = "All Categories" });

                foreach (var c in _categories) cmbCategory.Items.Add(c);

                cmbCategory.SelectedIndex = 0;
            }
            finally
            {
                cmbCategory.EndUpdate();
            }
        }

        private void LoadTransactions()
        {
            try
            {
                if (cmbCategory.SelectedItem is Category selected && selected.Id > 0)
                {
                    _transactions = _txRepo.GetTransactionsByCategory(selected.Id);
                }
                else
                {
                    _transactions = _txRepo.GetAllTransactions(CurrentUser.Id);
                }

                var userTx = _transactions.Where(t => t.UserId == CurrentUser.Id).ToList();

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("Date", typeof(string));
                table.Columns.Add("Category", typeof(string));
                table.Columns.Add("Amount", typeof(decimal));
                table.Columns.Add("Description", typeof(string));

                foreach (var tx in userTx)
                {
                    var cat = _categories.FirstOrDefault(c => c.Id == tx.CategoryId)?.Name ?? string.Empty;
                    table.Rows.Add(tx.Id, tx.TransactionDate?.ToString("yyyy-MM-dd") ?? string.Empty, cat, tx.Amount, tx.Description ?? string.Empty);
                }

                dgvTransactions.DataSource = table;
                if (dgvTransactions.Columns.Count > 0)
                    dgvTransactions.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error loading transactions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateBalance()
        {
            try
            {
                var balance = _txRepo.GetTotalBalance();
                lblBalance.Text = $"Balance: {balance:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error calculating balance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedTransactionId()
        {
            if (dgvTransactions.CurrentRow == null) return 0;
            var v = dgvTransactions.CurrentRow.Cells[0].Value;
            return v is int id ? id : 0;
        }

        private void btnSave_Click(
       object sender,
       EventArgs e)
        {
            TransactionForm form =
                new TransactionForm();

            form.ShowDialog();

            if (form.TransactionSaved)
            {
                LoadTransactions();

                CalculateBalance();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = GetSelectedTransactionId();
                if (id == 0)
                {
                    MessageBox.Show(this, "Please select a transaction to delete.");
                    return;
                }

                var confirm = MessageBox.Show(this, "Delete selected transaction?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                var ok = _txRepo.DeleteTransaction(id);
                if (ok)
                {
                    MessageBox.Show(this, "Transaction deleted.");
                    LoadTransactions();
                    CalculateBalance();
                }
                else
                {
                    MessageBox.Show(this, "Unable to delete transaction.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var userTx = _transactions.Where(t => t.UserId == CurrentUser.Id).ToList();
                if (userTx.Count == 0)
                {
                    MessageBox.Show(this, "No transactions to export.");
                    return;
                }

                using var sfd = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv", FileName = "transactions.csv" };
                if (sfd.ShowDialog(this) != DialogResult.OK) return;

                using var writer = new StreamWriter(sfd.FileName);
                writer.WriteLine("Id,Date,Category,Amount,Description");
                foreach (var tx in userTx)
                {
                    var cat = _categories.FirstOrDefault(c => c.Id == tx.CategoryId)?.Name ?? string.Empty;
                    var date = tx.TransactionDate?.ToString("yyyy-MM-dd") ?? string.Empty;
                    var desc = tx.Description?.Replace("\"", "''") ?? string.Empty;
                    writer.WriteLine($"{tx.Id},\"{date}\",\"{cat}\",{tx.Amount},\"{desc}\"");
                }

                MessageBox.Show(this, "Export complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTransactions();
            CalculateBalance();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) => LoadTransactions();

        private void mnuStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                var stats = new StatisticsForm();
                stats.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.Logout();
            Close();
        }

        private void mnuExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}
