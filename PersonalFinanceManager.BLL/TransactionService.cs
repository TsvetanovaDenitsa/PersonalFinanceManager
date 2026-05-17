using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinanceManager.DAL;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.BLL;

public sealed class TransactionService
{
    private readonly TransactionRepository _repository;

    public TransactionService(TransactionRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public void AddTransaction(Transaction tx)
    {
        if (tx is null)
            throw new ArgumentNullException(nameof(tx));

        if (tx.Amount <= 0)
            throw new ArgumentException("Transaction amount must be greater than zero.", nameof(tx.Amount));

        if (tx.CategoryId <= 0)
            throw new ArgumentException("Transaction must reference a valid category.", nameof(tx.CategoryId));

        tx.CreatedAt ??= DateTime.Now;
        tx.TransactionDate ??= DateTime.Now;

        _repository.AddTransaction(tx);
    }

    public List<Transaction> GetAllTransactions()
        => _repository.GetAllTransactions() ?? new List<Transaction>();

    public bool DeleteTransaction(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Transaction id must be a positive integer.", nameof(id));

        var deleted = _repository.DeleteTransaction(id);
        if (!deleted)
            throw new InvalidOperationException($"Transaction with id {id} could not be deleted.");

        return true;
    }

    public decimal GetBalance()
    {
        var transactions = _repository.GetAllTransactions();
        if (transactions == null || transactions.Count == 0)
            return 0m;

        return transactions.Aggregate(0m, (acc, t) =>
            acc + (string.Equals(t.TransactionType, "Income", StringComparison.OrdinalIgnoreCase) ? t.Amount : -t.Amount));
    }

    /// <summary>
    /// Total expenses (sum of amounts where TransactionType != 'Income') for the specified month/year.
    /// Defaults to current month if year/month are not provided.
    /// </summary>
    public decimal GetMonthlyExpenses(int? year = null, int? month = null)
    {
        var tx = _repository.GetAllTransactions() ?? new List<Transaction>();
        var y = year ?? DateTime.Now.Year;
        var m = month ?? DateTime.Now.Month;

        return tx
            .Where(t =>
            {
                var d = t.TransactionDate ?? t.CreatedAt;
                return d.HasValue && d.Value.Year == y && d.Value.Month == m;
            })
            .Where(t => !string.Equals(t.TransactionType, "Income", StringComparison.OrdinalIgnoreCase))
            .Sum(t => t.Amount);
    }

    /// <summary>
    /// Total income (sum of amounts where TransactionType == 'Income') for the specified month/year.
    /// Defaults to current month if year/month are not provided.
    /// </summary>
    public decimal GetMonthlyIncome(int? year = null, int? month = null)
    {
        var tx = _repository.GetAllTransactions() ?? new List<Transaction>();
        var y = year ?? DateTime.Now.Year;
        var m = month ?? DateTime.Now.Month;

        return tx
            .Where(t =>
            {
                var d = t.TransactionDate ?? t.CreatedAt;
                return d.HasValue && d.Value.Year == y && d.Value.Month == m;
            })
            .Where(t => string.Equals(t.TransactionType, "Income", StringComparison.OrdinalIgnoreCase))
            .Sum(t => t.Amount);
    }

    /// <summary>
    /// Returns total expenses grouped by CategoryId for the specified month/year.
    /// Each item is (CategoryId, Total).
    /// </summary>
    public List<(int CategoryId, decimal Total)> GetExpensesByCategory(int? year = null, int? month = null)
    {
        var tx = _repository.GetAllTransactions() ?? new List<Transaction>();
        var y = year ?? DateTime.Now.Year;
        var m = month ?? DateTime.Now.Month;

        return tx
            .Where(t =>
            {
                var d = t.TransactionDate ?? t.CreatedAt;
                return d.HasValue && d.Value.Year == y && d.Value.Month == m;
            })
            .Where(t => !string.Equals(t.TransactionType, "Income", StringComparison.OrdinalIgnoreCase))
            .GroupBy(t => t.CategoryId)
            .Select(g => (CategoryId: g.Key, Total: g.Sum(x => x.Amount)))
            .OrderByDescending(x => x.Total)
            .ToList();
    }

    /// <summary>
    /// Returns income and expenses totals for a given month/year as (Income, Expenses).
    /// </summary>
    public (decimal Income, decimal Expenses) GetIncomeVsExpenses(int? year = null, int? month = null)
    {
        var income = GetMonthlyIncome(year, month);
        var expenses = GetMonthlyExpenses(year, month);
        return (income, expenses);
    }

    /// <summary>
    /// Returns the most recent transactions ordered by TransactionDate (or CreatedAt fallback).
    /// </summary>
    public List<Transaction> GetRecentTransactions(int count = 10)
    {
        var tx = _repository.GetAllTransactions() ?? new List<Transaction>();
        return tx
            .OrderByDescending(t => t.TransactionDate ?? t.CreatedAt ?? DateTime.MinValue)
            .Take(Math.Max(1, count))
            .ToList();
    }
}
