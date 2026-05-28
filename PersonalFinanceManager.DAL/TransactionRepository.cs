using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL;

public sealed class TransactionRepository
{
    private readonly DatabaseManager _db;

    public TransactionRepository(DatabaseManager db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public bool AddTransaction(Transaction tx)
    {
        if (tx is null) throw new ArgumentNullException(nameof(tx));

        const string sql = @"INSERT INTO Transactions (UserId, CategoryId, Amount, Description, TransactionType, TransactionDate, CreatedAt)
VALUES (@UserId, @CategoryId, @Amount, @Description, @TransactionType, @TransactionDate, @CreatedAt);";

        return ExecuteNonQuery(sql, cmd =>
        {
            cmd.Parameters.AddWithValue("@UserId", tx.UserId);
            cmd.Parameters.AddWithValue("@CategoryId", tx.CategoryId);
            cmd.Parameters.AddWithValue("@Amount", tx.Amount);
            cmd.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(tx.Description) ? (object)DBNull.Value : tx.Description);
            cmd.Parameters.AddWithValue("@TransactionType", tx.TransactionType ?? string.Empty);
            cmd.Parameters.AddWithValue("@TransactionDate", tx.TransactionDate.HasValue ? (object)tx.TransactionDate.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedAt", tx.CreatedAt.HasValue ? (object)tx.CreatedAt.Value : DateTime.Now);
        });
    }

    public List<Transaction> GetAllTransactions()
    {
        const string sql = @"SELECT Id, UserId, CategoryId, Amount, Description, TransactionType, TransactionDate, CreatedAt
FROM Transactions
ORDER BY TransactionDate DESC, CreatedAt DESC";

        return ExecuteQuery(sql, null);
    }

    public List<Transaction> GetAllTransactions(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("User id must be positive.", nameof(userId));

        const string sql = @"SELECT Id, UserId, CategoryId, Amount, Description, TransactionType, TransactionDate, CreatedAt
FROM Transactions
WHERE UserId = @UserId
ORDER BY TransactionDate DESC, CreatedAt DESC";

        return ExecuteQuery(sql, cmd =>
        {
            cmd.Parameters.AddWithValue("@UserId", userId);
        });
    }

    public Transaction? GetTransactionById(int id)
    {
        if (id <= 0) throw new ArgumentException("Id must be a positive integer.", nameof(id));

        const string sql = @"SELECT Id, UserId, CategoryId, Amount, Description, TransactionType, TransactionDate, CreatedAt
FROM Transactions WHERE Id = @Id";

        var list = ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@Id", id));
        return list.Count == 0 ? null : list[0];
    }

    public bool UpdateTransaction(Transaction tx)
    {
        if (tx is null) throw new ArgumentNullException(nameof(tx));
        if (tx.Id <= 0) throw new ArgumentException("Transaction id must be a positive integer.", nameof(tx.Id));

        const string sql = @"UPDATE Transactions SET UserId = @UserId, CategoryId = @CategoryId, Amount = @Amount,
Description = @Description, TransactionType = @TransactionType, TransactionDate = @TransactionDate
WHERE Id = @Id";

        return ExecuteNonQuery(sql, cmd =>
        {
            cmd.Parameters.AddWithValue("@UserId", tx.UserId);
            cmd.Parameters.AddWithValue("@CategoryId", tx.CategoryId);
            cmd.Parameters.AddWithValue("@Amount", tx.Amount);
            cmd.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(tx.Description) ? (object)DBNull.Value : tx.Description);
            cmd.Parameters.AddWithValue("@TransactionType", tx.TransactionType ?? string.Empty);
            cmd.Parameters.AddWithValue("@TransactionDate", tx.TransactionDate.HasValue ? (object)tx.TransactionDate.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Id", tx.Id);
        });
    }

    public bool DeleteTransaction(int id)
    {
        if (id <= 0) throw new ArgumentException("Id must be a positive integer.", nameof(id));
        const string sql = "DELETE FROM Transactions WHERE Id = @Id";
        return ExecuteNonQuery(sql, cmd => cmd.Parameters.AddWithValue("@Id", id));
    }

    public List<Transaction> GetRecentTransactions(int count = 10)
    {
        if (count <= 0) throw new ArgumentException("Count must be positive.", nameof(count));
        const string sql = @"SELECT TOP(@Count) Id, UserId, CategoryId, Amount, Description, TransactionType, TransactionDate, CreatedAt
FROM Transactions
ORDER BY TransactionDate DESC, CreatedAt DESC";

        return ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@Count", count));
    }

    public List<Transaction> GetTransactionsByCategory(int categoryId)
    {
        if (categoryId <= 0) throw new ArgumentException("Category id must be positive.", nameof(categoryId));
        const string sql = @"SELECT Id, UserId, CategoryId, Amount, Description, TransactionType, TransactionDate, CreatedAt
FROM Transactions WHERE CategoryId = @CategoryId ORDER BY TransactionDate DESC";

        return ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@CategoryId", categoryId));
    }

    public decimal GetMonthlyExpenses(int year, int month)
    {
        const string sql = @"SELECT ISNULL(SUM(Amount), 0) FROM Transactions WHERE TransactionType <> 'Income' AND YEAR(TransactionDate) = @Year AND MONTH(TransactionDate) = @Month";
        return ExecuteScalarDecimal(sql, cmd =>
        {
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Month", month);
        });
    }

    public decimal GetMonthlyIncome(int year, int month)
    {
        const string sql = @"SELECT ISNULL(SUM(Amount), 0) FROM Transactions WHERE TransactionType = 'Income' AND YEAR(TransactionDate) = @Year AND MONTH(TransactionDate) = @Month";

        return ExecuteScalarDecimal(sql, cmd =>
        {
            cmd.Parameters.AddWithValue("@Year", year);
            cmd.Parameters.AddWithValue("@Month", month);
        });
    }

    public decimal GetTotalBalance()
    {
        const string sql = @"SELECT ISNULL(SUM(CASE WHEN TransactionType = 'Income' THEN Amount ELSE -Amount END), 0) FROM Transactions";
        return ExecuteScalarDecimal(sql, null);
    }

    #region Helper Methods

    private List<Transaction> ExecuteQuery(string sql, Action<SqlCommand>? parameterize)
    {
        try
        {
            var list = new List<Transaction>();
            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand(sql, conn);
            parameterize?.Invoke(cmd);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(MapReaderToTransaction(reader));
            return list;
        }
        catch (SqlException ex)
        {
            throw new InvalidOperationException("Database query error.", ex);
        }
    }

    private bool ExecuteNonQuery(string sql, Action<SqlCommand>? parameterize)
    {
        try
        {
            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand(sql, conn);
            parameterize?.Invoke(cmd);
            conn.Open();
            var affected = cmd.ExecuteNonQuery();
            return affected > 0;
        }
        catch (SqlException ex)
        {
            throw new InvalidOperationException("Database non-query error.", ex);
        }
    }

    private decimal ExecuteScalarDecimal(string sql, Action<SqlCommand>? parameterize)
    {
        try
        {
            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand(sql, conn);
            parameterize?.Invoke(cmd);
            conn.Open();
            var result = cmd.ExecuteScalar();
            return Convert.ToDecimal(result ?? 0m);
        }
        catch (SqlException ex)
        {
            throw new InvalidOperationException("Database scalar error.", ex);
        }
    }

    #endregion

    private static Transaction MapReaderToTransaction(SqlDataReader reader)
    {
        return new Transaction
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
            CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
            Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
            TransactionType = reader.GetString(reader.GetOrdinal("TransactionType")),
            TransactionDate = reader.IsDBNull(reader.GetOrdinal("TransactionDate")) ? null : reader.GetDateTime(reader.GetOrdinal("TransactionDate")),
            CreatedAt = reader.IsDBNull(reader.GetOrdinal("CreatedAt")) ? null : reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
        };
    }
}


