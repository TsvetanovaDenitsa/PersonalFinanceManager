using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PersonalFinanceManager.BLL;
using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.UI
{
    public partial class MainDashboardForm : Form
    {
        private readonly DatabaseManager _db;
        private readonly TransactionService _txService;
        private readonly CategoryService _catService;

        public MainDashboardForm()
        {
            InitializeComponent();

            _db = new DatabaseManager();
            var txRepo = new TransactionRepository(_db);
            var catRepo = new CategoryRepository(_db);

            _txService = new TransactionService(txRepo);
            _catService = new CategoryService(catRepo);

            _ = LoadDashboardAsync();
        }

        private async Task LoadDashboardAsync()
        {
            try
            {
                await Task.WhenAll(
                    Task.Run(() => LoadCurrentBalance()),
                    Task.Run(() => LoadMonthlyExpenses()),
                    Task.Run(() => LoadMonthlyIncome()),
                    Task.Run(() => LoadRecentTransactions()),
                    Task.Run(() => LoadQuickStatisticsChart())
                ).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCurrentBalance()
        {
            try
            {
                var balance = _txService.GetBalance();
                if (InvokeRequired)
                {
                    Invoke(new Action(() => lblCurrentBalance.Text = $"{balance:C}"));
                }
                else
                {
                    lblCurrentBalance.Text = $"{balance:C}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load balance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonthlyExpenses()
        {
            try
            {
                var expenses = _txService.GetMonthlyExpenses();
                if (InvokeRequired)
                    Invoke(new Action(() => lblMonthlyExpenses.Text = $"{expenses:C}"));
                else
                    lblMonthlyExpenses.Text = $"{expenses:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load monthly expenses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonthlyIncome()
        {
            try
            {
                var income = _txService.GetMonthlyIncome();
                if (InvokeRequired)
                    Invoke(new Action(() => lblMonthlyIncome.Text = $"{income:C}"));
                else
                    lblMonthlyIncome.Text = $"{income:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load monthly income: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentTransactions()
        {
            try
            {
                var recent = _txService.GetRecentTransactions(10);

                var categories = _catService.GetAllCategories().ToDictionary(c => c.Id, c => c.Name);

                var table = new DataTable();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("Category", typeof(string));
                table.Columns.Add("Amount", typeof(decimal));
                table.Columns.Add("Type", typeof(string));
                table.Columns.Add("Date", typeof(DateTime));

                foreach (var tx in recent)
                {
                    var catName = categories.TryGetValue(tx.CategoryId, out var name) ? name : string.Empty;
                    table.Rows.Add(tx.Id, catName, tx.Amount, tx.TransactionType, tx.TransactionDate ?? DateTime.MinValue);
                }

                if (InvokeRequired)
                {
                    Invoke(new Action(() => dgvRecentTransactions.DataSource = table));
                }
                else
                {
                    dgvRecentTransactions.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load recent transactions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadQuickStatisticsChart()
        {
            try
            {
                var expensesByCategory = _txService.GetExpensesByCategory();
                var categories = _catService.GetAllCategories().ToDictionary(c => c.Id, c => c.Name);

                if (InvokeRequired)
                {
                    Invoke(new Action(() => PopulateQuickChart(expensesByCategory, categories)));
                }
                else
                {
                    PopulateQuickChart(expensesByCategory, categories);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load quick statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateQuickChart(System.Collections.Generic.List<(int CategoryId, decimal Total)> data, System.Collections.Generic.Dictionary<int, string> categories)
        {
            try
            {
                chartQuickStatistics.Series.Clear();
                if (chartQuickStatistics.ChartAreas.Count == 0)
                    chartQuickStatistics.ChartAreas.Add(new ChartArea("Main"));

                var series = new Series("Expenses")
                {
                    ChartType = SeriesChartType.Pie,
                    ChartArea = chartQuickStatistics.ChartAreas[0].Name,
                    IsValueShownAsLabel = true
                };

                foreach (var item in data)
                {
                    var label = categories.TryGetValue(item.CategoryId, out var name) ? name : "Uncategorized";
                    var ptIdx = series.Points.Add((double)item.Total);
                    var pt = series.Points[ptIdx];
                    pt.Label = $"{label}: {item.Total:C}";
                    pt.LegendText = label;
                }

                chartQuickStatistics.Series.Add(series);

                if (chartQuickStatistics.Legends.Count == 0)
                    chartQuickStatistics.Legends.Add(new Legend("Legend"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to populate quick chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _ = LoadDashboardAsync();
        }

        private void btnOpenStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                using var frm = new StatisticsForm();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to open statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Add transaction UI not implemented.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
