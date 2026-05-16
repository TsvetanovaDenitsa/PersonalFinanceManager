using System;
using System.Collections.Generic;
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
        if (tx is null) throw new ArgumentNullException(nameof(tx));
        if (tx.Amount < 0) throw new ArgumentException("Amount cannot be negative.", nameof(tx.Amount));

        _repository.AddTransaction(tx);
    }

    public List<Transaction> GetAllTransactions()
        => _repository.GetAllTransactions();

    public bool UpdateTransaction(Transaction tx)
    {
        if (tx is null) throw new ArgumentNullException(nameof(tx));
        if (tx.Amount < 0) throw new ArgumentException("Amount cannot be negative.", nameof(tx.Amount));

        return _repository.UpdateTransaction(tx);
    }

    public bool DeleteTransaction(int id)
    {
        if (id <= 0) throw new ArgumentException("Id must be a positive integer.", nameof(id));
        return _repository.DeleteTransaction(id);
    }
}
