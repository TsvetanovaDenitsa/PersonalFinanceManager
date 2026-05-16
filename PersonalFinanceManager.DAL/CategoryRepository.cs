using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.DAL;

public sealed class CategoryRepository
{
    private readonly DatabaseManager _db;

    public CategoryRepository(DatabaseManager db)
    {
        _db = db;
    }

    public List<Category> GetAllCategories()
    {
        var list = new List<Category>();
        const string query = "SELECT Id, Name, Description FROM Categories ORDER BY Name";

        using var conn = _db.GetConnection();
        using var cmd = new SqlCommand(query, conn);
        conn.Open();
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var cat = new Category
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"))
            };

            list.Add(cat);
        }

        return list;
    }
}
