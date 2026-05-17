using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL;

public sealed class CategoryRepository
{
    private readonly DatabaseManager _db;

    public CategoryRepository(DatabaseManager db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public List<Category> GetAllCategories()
    {
        const string sql = "SELECT Id, Name, Description FROM Categories ORDER BY Name";
        return ExecuteQuery(sql, null);
    }

    public Category? GetCategoryById(int id)
    {
        if (id <= 0) throw new ArgumentException("Id must be a positive integer.", nameof(id));
        const string sql = "SELECT Id, Name, Description FROM Categories WHERE Id = @Id";
        var list = ExecuteQuery(sql, cmd => cmd.Parameters.AddWithValue("@Id", id));
        return list.Count == 0 ? null : list[0];
    }

    public bool AddCategory(Category category)
    {
        if (category is null) throw new ArgumentNullException(nameof(category));
        const string sql = "INSERT INTO Categories (Name, Description) VALUES (@Name, @Description)";
        return ExecuteNonQuery(sql, cmd =>
        {
            cmd.Parameters.AddWithValue("@Name", category.Name);
            cmd.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(category.Description) ? (object)DBNull.Value : category.Description);
        });
    }

    public bool UpdateCategory(Category category)
    {
        if (category is null) throw new ArgumentNullException(nameof(category));
        if (category.Id <= 0) throw new ArgumentException("Category id must be positive.", nameof(category.Id));

        const string sql = "UPDATE Categories SET Name = @Name, Description = @Description WHERE Id = @Id";
        return ExecuteNonQuery(sql, cmd =>
        {
            cmd.Parameters.AddWithValue("@Name", category.Name);
            cmd.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(category.Description) ? (object)DBNull.Value : category.Description);
            cmd.Parameters.AddWithValue("@Id", category.Id);
        });
    }

    public bool DeleteCategory(int id)
    {
        if (id <= 0) throw new ArgumentException("Id must be a positive integer.", nameof(id));
        const string sql = "DELETE FROM Categories WHERE Id = @Id";
        return ExecuteNonQuery(sql, cmd => cmd.Parameters.AddWithValue("@Id", id));
    }

    private List<Category> ExecuteQuery(string sql, Action<SqlCommand>? parameterize)
    {
        try
        {
            var list = new List<Category>();
            using var conn = _db.GetConnection();
            using var cmd = new SqlCommand(sql, conn);
            parameterize?.Invoke(cmd);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Category
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"))
                });
            }

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
}
