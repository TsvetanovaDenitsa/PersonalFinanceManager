using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;
using PersonalFinanceManager;

namespace PersonalFinanceManager
{
    public partial class Form1 : Form
    {
        private readonly DatabaseManager _db;
        private readonly TransactionRepository _txRepo;
        private readonly CategoryRepository _catRepo;

        public Form1()
        {
            InitializeComponent();

            _db = new DatabaseManager();
            _txRepo = new TransactionRepository(_db);
            _catRepo = new CategoryRepository(_db);

            // initialize asynchronously
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await LoadCategoriesAsync().ConfigureAwait(true);
            await LoadTransactionsAsync().ConfigureAwait(true);
            CalculateBalance();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var cats = await Task.Run(() => _catRepo.GetAllCategories()).ConfigureAwait(true);

                var list = new List<Category> { new Category { Id = 0, Name = "All" } };
                list.AddRange(cats);

                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
                cmbCategory.DataSource = list;
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTransactionsAsync()
        {
            try
            {
                var transactions = await Task.Run(() => _txRepo.GetAllTransactions()).ConfigureAwait(true);
                var categories = await Task.Run(() => _catRepo.GetAllCategories()).ConfigureAwait(true);
                var catDict = categories.ToDictionary(c => c.Id, c => c.Name);

                string selectedCategoryName = null;
                if (cmbCategory?.SelectedItem is Category sel)
                    selectedCategoryName = sel.Name;

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("Category", typeof(string));
                table.Columns.Add("Amount", typeof(decimal));
                table.Columns.Add("Description", typeof(string));
                table.Columns.Add("TransactionType", typeof(string));
                table.Columns.Add("TransactionDate", typeof(DateTime));

                foreach (var tx in transactions)
                {
                    var catName = catDict.TryGetValue(tx.CategoryId, out var n) ? n : string.Empty;

                    if (!string.IsNullOrWhiteSpace(selectedCategoryName) && selectedCategoryName != "All")
                    {
                        if (!string.Equals(catName, selectedCategoryName, StringComparison.OrdinalIgnoreCase))
                            continue;
                    }

                    table.Rows.Add(tx.Id, catName, tx.Amount, tx.Description ?? string.Empty, tx.TransactionType, tx.TransactionDate ?? DateTime.MinValue);
                }

                dgvTransactions.DataSource = table;
                CalculateBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateBalance()
        {
            try
            {
                decimal balance = 0m;
                if (dgvTransactions.DataSource is DataTable table)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var type = row.Field<string>("TransactionType");
                        var amt = row.Field<decimal>("Amount");
                        balance += string.Equals(type, "Income", StringComparison.OrdinalIgnoreCase) ? amt : -amt;
                    }
                }

                lblBalance.Text = $"Balance: {balance:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to calculate balance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedTransactionId()
        {
            try
            {
                if (dgvTransactions.SelectedRows.Count == 0)
                    return -1;

                var row = dgvTransactions.SelectedRows[0];
                if (row.DataBoundItem is DataRowView drv)
                    return drv.Row.Field<int>("Id");

                var cell = row.Cells["Id"];
                if (cell?.Value is int i)
                    return i;

                if (int.TryParse(cell?.Value?.ToString(), out var parsed))
                    return parsed;

                return -1;
            }
            catch
            {
                return -1;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtAmount.Text, out var amount))
                {
                    MessageBox.Show(this, "Please enter a valid amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!(cmbCategory?.SelectedItem is Category selectedCat) || selectedCat.Id == 0)
                {
                    MessageBox.Show(this, "Please select a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var tx = new Transaction
                {
                    UserId = 1,
                    CategoryId = selectedCat.Id,
                    Amount = amount,
                    Description = string.Empty,
                    TransactionType = "Expense",
                    TransactionDate = DateTime.Now,
                    CreatedAt = DateTime.Now
                };

                await Task.Run(() => _txRepo.AddTransaction(tx)).ConfigureAwait(true);
                await LoadTransactionsAsync().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to save transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = GetSelectedTransactionId();
                if (id <= 0)
                {
                    MessageBox.Show(this, "Please select a transaction to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(this, "Are you sure you want to delete the selected transaction?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;

                var ok = await Task.Run(() => _txRepo.DeleteTransaction(id)).ConfigureAwait(true);
                if (!ok)
                    MessageBox.Show(this, "Failed to delete transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                await LoadTransactionsAsync().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to delete transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransactions.DataSource is not DataTable table || table.Rows.Count == 0)
                {
                    MessageBox.Show(this, "No transactions to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var sfd = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv", FileName = "transactions.csv" };
                if (sfd.ShowDialog(this) != DialogResult.OK)
                    return;

                using var writer = new StreamWriter(sfd.FileName);

                // headers
                var columnNames = table.Columns.Cast<DataColumn>().Select(c => EscapeCsv(c.ColumnName));
                writer.WriteLine(string.Join(',', columnNames));

                // rows
                foreach (DataRow row in table.Rows)
                {
                    var fields = table.Columns.Cast<DataColumn>().Select(c => EscapeCsv(row[c]?.ToString() ?? string.Empty));
                    writer.WriteLine(string.Join(',', fields));
                }

                MessageBox.Show(this, "Export completed.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                _ = LoadTransactionsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to refresh: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadTransactionsAsync().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to filter by category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string EscapeCsv(string input)
        {
            return input.Contains(',') || input.Contains('"') || input.Contains('\n')
                ? '"' + input.Replace("\"", "\"\"") + '"'
                : input;
        }

        // Menu handlers
        private void mnuStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                using var frm = new StatisticsForm();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to open Statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuDashboard_Click(object sender, EventArgs e)
        {
            // Dashboard is the main form; bring to front or refresh
            try
            {
                this.BringToFront();
                _ = LoadTransactionsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to refresh dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuCategories_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Categories management not implemented in UI.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuBudgets_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Budgets management not implemented in UI.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Settings not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
