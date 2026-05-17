using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PersonalFinanceManager.BLL;
using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager
{
    public partial class StatisticsForm : Form
    {
        private readonly DatabaseManager _db;
        private readonly TransactionService _txService;
        private readonly CategoryService _catService;

        public StatisticsForm()
        {
            InitializeComponent();

            // Initialize data access and services
            _db = new DatabaseManager();
            var txRepo = new TransactionRepository(_db);
            var catRepo = new CategoryRepository(_db);

            _txService = new TransactionService(txRepo);
            _catService = new CategoryService(catRepo);

            // Start asynchronous load without blocking constructor
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            try
            {
                await LoadStatisticsAsync().ConfigureAwait(true);
                await LoadExpenseChartAsync().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                // Show error on UI thread
                MessageBox.Show(this, $"Failed to initialize statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadStatisticsAsync()
        {
            try
            {
                // Fetch transactions off the UI thread
                var transactions = await Task.Run(() => _txService.GetAllTransactions()).ConfigureAwait(true);

                // Get total balance from service
                var totalBalance = await Task.Run(() => _txService.GetBalance()).ConfigureAwait(true);

                // Compute monthly totals
                var now = DateTime.Now;
                var monthly = transactions
                    .Where(t => t.TransactionDate.HasValue && t.TransactionDate.Value.Year == now.Year && t.TransactionDate.Value.Month == now.Month)
                    .ToList();

                var monthlyIncome = monthly.Where(t => string.Equals(t.TransactionType, "Income", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount);
                var monthlyExpenses = monthly.Where(t => !string.Equals(t.TransactionType, "Income", StringComparison.OrdinalIgnoreCase)).Sum(t => t.Amount);

                // Marshal UI updates to the UI thread
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        UpdateStatisticLabels(totalBalance, monthlyIncome, monthlyExpenses);
                    }));
                }
                else
                {
                    UpdateStatisticLabels(totalBalance, monthlyIncome, monthlyExpenses);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatisticLabels(decimal totalBalance, decimal monthlyIncome, decimal monthlyExpenses)
        {
            // It is assumed the form contains labels with these names.
            // If labels are not present, these operations will be no-ops in practice (designer should define them).
            if (this.Controls.Find("lblTotalBalance", true).FirstOrDefault() is Label lblTotalBalance)
                lblTotalBalance.Text = $"Total Balance: {totalBalance:C}";

            if (this.Controls.Find("lblMonthlyIncome", true).FirstOrDefault() is Label lblMonthlyIncome)
                lblMonthlyIncome.Text = $"Monthly Income: {monthlyIncome:C}";

            if (this.Controls.Find("lblMonthlyExpenses", true).FirstOrDefault() is Label lblMonthlyExpenses)
                lblMonthlyExpenses.Text = $"Monthly Expenses: {monthlyExpenses:C}";
        }

        private async Task LoadExpenseChartAsync()
        {
            try
            {
                var transactions = await Task.Run(() => _txService.GetAllTransactions()).ConfigureAwait(true);
                var categories = await Task.Run(() => _catService.GetAllCategories()).ConfigureAwait(true);
                var catDict = categories.ToDictionary(c => c.Id, c => c.Name);

                var now = DateTime.Now;
                var expenses = transactions
                    .Where(t => !string.Equals(t.TransactionType, "Income", StringComparison.OrdinalIgnoreCase))
                    .Where(t => t.TransactionDate.HasValue && t.TransactionDate.Value.Year == now.Year && t.TransactionDate.Value.Month == now.Month)
                    .GroupBy(t => t.CategoryId)
                    .Select(g => (CategoryId: g.Key, Total: g.Sum(x => x.Amount)))
                    .Where(x => x.Total > 0)
                    .OrderByDescending(x => x.Total)
                    .ToList();

                // Update chart on UI thread
                if (InvokeRequired)
                {
                    Invoke(new Action(() => PopulateExpenseChart(expenses, catDict)));
                }
                else
                {
                    PopulateExpenseChart(expenses, catDict);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Failed to load expense chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateExpenseChart(List<(int CategoryId, decimal Total)> expenses, Dictionary<int, string> catDict)
        {
            // It is assumed the form contains a Chart named chartExpenses.
            if (this.Controls.Find("chartExpenses", true).FirstOrDefault() is Chart chartExpenses)
            {
                chartExpenses.Series.Clear();

                if (chartExpenses.ChartAreas.Count == 0)
                    chartExpenses.ChartAreas.Add(new ChartArea("Default"));

                var series = new Series("Expenses")
                {
                    ChartType = SeriesChartType.Pie,
                    ChartArea = chartExpenses.ChartAreas[0].Name,
                    IsValueShownAsLabel = true,
                    Font = new Font("Segoe UI", 9F)
                };

                foreach (var item in expenses)
                {
                    var label = catDict.TryGetValue(item.CategoryId, out var name) ? name : "Uncategorized";
                    int idx = series.Points.AddY((double)item.Total);
                    var dp = series.Points[idx];
                    dp.Label = $"{label}: {item.Total:C}";
                    dp.LegendText = label;
                }

                chartExpenses.Series.Add(series);

                // Optional: adjust legend
                if (chartExpenses.Legends.Count == 0)
                    chartExpenses.Legends.Add(new Legend("Legend"));
            }
        }

        // Optional refresh handler - wire this up in the designer to a Refresh button if present.
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await InitializeAsync().ConfigureAwait(true);
        }
    }
}
