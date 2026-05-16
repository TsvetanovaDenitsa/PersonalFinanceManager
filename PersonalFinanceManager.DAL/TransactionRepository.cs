using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL;

public sealed class TransactionRepository
{
    private readonly DatabaseManager _db;

    public TransactionRepository(DatabaseManager db)
    {
        _db = db;
    }

    public void AddTransaction(Transaction tx)
    {
        const string query = @"INSERT INTO Transactions (UserId, CategoryId, Amount, Description, TransactionType, TransactionDate, CreatedAt)
VALUES (@UserId, @CategoryId, @Amount, @Description, @TransactionType, @TransactionDate, @CreatedAt);";

        using var conn = _db.GetConnection();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@UserId", tx.UserId);
        cmd.Parameters.AddWithValue("@CategoryId", tx.CategoryId);
        cmd.Parameters.AddWithValue("@Amount", tx.Amount);
        cmd.Parameters.AddWithValue("@Description", (object?)tx.Description ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@TransactionType", tx.TransactionType);
        cmd.Parameters.AddWithValue("@TransactionDate", (object?)tx.TransactionDate ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CreatedAt", (object?)tx.CreatedAt ?? DBNull.Value);

        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public List<Transaction> GetAllTransactions()
    {
        var list = new List<Transaction>();
        const string query = "SELECT Id, UserId, CategoryId, Amount, Description, TransactionType, TransactionDate, CreatedAt FROM Transactions ORDER BY CreatedAt DESC";

        using var conn = _db.GetConnection();
        using var cmd = new SqlCommand(query, conn);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var tx = new Transaction
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

            list.Add(tx);
        }

        return list;
    }

    public Transaction? GetTransactionById(int id)
    {
        const string query = "SELECT Id, UserId, CategoryId, Amount, Description, TransactionType, TransactionDate, CreatedAt FROM Transactions WHERE Id = @Id";

        using var conn = _db.GetConnection();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        if (!reader.Read())
            return null;

        var tx = new Transaction
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

        return tx;
    }

    public bool UpdateTransaction(Transaction tx)
    {
        const string query = @"UPDATE Transactions
SET UserId = @UserId,
    CategoryId = @CategoryId,
    Amount = @Amount,
    Description = @Description,
    TransactionType = @TransactionType,
    TransactionDate = @TransactionDate,
    CreatedAt = @CreatedAt
WHERE Id = @Id";

        using var conn = _db.GetConnection();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@UserId", tx.UserId);
        cmd.Parameters.AddWithValue("@CategoryId", tx.CategoryId);
        cmd.Parameters.AddWithValue("@Amount", tx.Amount);
        cmd.Parameters.AddWithValue("@Description", (object?)tx.Description ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@TransactionType", tx.TransactionType);
        cmd.Parameters.AddWithValue("@TransactionDate", (object?)tx.TransactionDate ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CreatedAt", (object?)tx.CreatedAt ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Id", tx.Id);

        conn.Open();
        var affected = cmd.ExecuteNonQuery();
        return affected > 0;
    }

    public bool DeleteTransaction(int id)
    {
        const string query = "DELETE FROM Transactions WHERE Id = @Id";

        using var conn = _db.GetConnection();
        using var cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        conn.Open();
        var affected = cmd.ExecuteNonQuery();
        return affected > 0;
    }
}

