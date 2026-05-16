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
}
