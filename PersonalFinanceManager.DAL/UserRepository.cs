using System;
using Microsoft.Data.SqlClient;
using PersonalFinanceManager.Models;
using System.Collections.Generic;

namespace PersonalFinanceManager.DAL;

public sealed class UserRepository
{
    private readonly DatabaseManager _db;

    public UserRepository(DatabaseManager db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public bool AddUser(User user)
    {
        const string sql = @"INSERT INTO Users (Username, Email, PasswordHash, FirstName, LastName, CreatedAt)
VALUES (@Username, @Email, @PasswordHash, @FirstName, @LastName, @CreatedAt);";

        using var conn = _db.GetConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Username", user.Username);
        cmd.Parameters.AddWithValue("@Email", user.Email);
        cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
        cmd.Parameters.AddWithValue("@FirstName", (object?)user.FirstName ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@LastName", (object?)user.LastName ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@CreatedAt", (object?)user.CreatedAt ?? DateTime.Now);

        conn.Open();
        var affected = cmd.ExecuteNonQuery();
        return affected > 0;
    }

    public User? ValidateLogin(string usernameOrEmail, string passwordHash)
    {
        const string sql = @"SELECT Id, Username, Email, PasswordHash, FirstName, LastName, CreatedAt
FROM Users
WHERE (Username = @Input OR Email = @Input) AND PasswordHash = @PasswordHash";

        using var conn = _db.GetConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Input", usernameOrEmail);
        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

        conn.Open();
        using var reader = cmd.ExecuteReader();
        if (!reader.Read()) return null;

        return new User
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            Username = reader.GetString(reader.GetOrdinal("Username")),
            Email = reader.GetString(reader.GetOrdinal("Email")),
            PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
            FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? null : reader.GetString(reader.GetOrdinal("FirstName")),
            LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? null : reader.GetString(reader.GetOrdinal("LastName")),
            CreatedAt = reader.IsDBNull(reader.GetOrdinal("CreatedAt")) ? null : reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
        };
    }

    public bool UserExistsByUsername(string username)
    {
        const string sql = "SELECT COUNT(1) FROM Users WHERE Username = @Username";
        using var conn = _db.GetConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Username", username);
        conn.Open();
        var result = cmd.ExecuteScalar();
        return Convert.ToInt32(result) > 0;
    }

    public bool UserExistsByEmail(string email)
    {
        const string sql = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
        using var conn = _db.GetConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Email", email);
        conn.Open();
        var result = cmd.ExecuteScalar();
        return Convert.ToInt32(result) > 0;
    }
}
