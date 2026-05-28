// StatisticsForm.cs

using System.Windows.Forms.DataVisualization.Charting;
using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager;

public partial class StatisticsForm : Form
{
    private readonly DatabaseManager _db;

    private readonly TransactionRepository _txRepo;

    private readonly CategoryRepository _catRepo;

    public StatisticsForm()
    {
        InitializeComponent();

        _db = new DatabaseManager();

        _txRepo =
            new TransactionRepository(_db);

        _catRepo =
            new CategoryRepository(_db);

        LoadStatistics();
    }

    private void LoadStatistics()
    {
        LoadPieChart();

        LoadMonthlyStatistics();

        LoadSummary();
    }

    private void LoadPieChart()
    {
        chartExpenses.Series.Clear();

        Series series =
            new Series("Expenses");

        series.ChartType =
            SeriesChartType.Pie;

        List<Transaction> transactions =
            _txRepo.GetAllTransactions(
                CurrentUser.Id);

        List<Category> categories =
            _catRepo.GetAllCategories();

        var grouped =
            transactions
                .Where(t =>
                    t.TransactionType ==
                    "Expense")
                .GroupBy(t =>
                    t.CategoryId)
                .Select(g => new
                {
                    CategoryId = g.Key,

                    Total = g.Sum(
                        x => x.Amount)
                })
                .ToList();

        foreach (var item in grouped)
        {
            Category? category =
                categories.FirstOrDefault(
                    c => c.Id ==
                         item.CategoryId);

            string name =
                category?.Name ??
                "Unknown";

            series.Points.AddXY(
                name,
                item.Total);
        }

        chartExpenses.Series.Add(
            series);
    }

    private void LoadMonthlyStatistics()
    {
        List<Transaction> transactions =
            _txRepo.GetAllTransactions(
                CurrentUser.Id);

        decimal income =
            transactions
                .Where(t =>
                    t.TransactionType ==
                    "Income")
                .Sum(t => t.Amount);

        decimal expenses =
            transactions
                .Where(t =>
                    t.TransactionType ==
                    "Expense")
                .Sum(t => t.Amount);

        lblIncome.Text =
            $"Total Income: {income:C}";

        lblExpenses.Text =
            $"Total Expenses: {expenses:C}";
    }

    private void LoadSummary()
    {
        List<Transaction> transactions =
            _txRepo.GetAllTransactions(
                CurrentUser.Id);

        decimal balance = 0;

        foreach (Transaction transaction
                 in transactions)
        {
            if (transaction
                .TransactionType ==
                "Income")
            {
                balance +=
                    transaction.Amount;
            }
            else
            {
                balance -=
                    transaction.Amount;
            }
        }

        lblBalance.Text =
            $"Current Balance: {balance:C}";

        lblTransactions.Text =
            $"Transactions: {transactions.Count}";
    }

    private void btnClose_Click(
        object sender,
        EventArgs e)
    {
        Close();
    }
}