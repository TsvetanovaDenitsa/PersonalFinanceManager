using Microsoft.Data.SqlClient;

namespace PersonalFinanceManager.DAL;

public sealed class DatabaseManager
{
    private readonly string _connectionString;

    public DatabaseManager(string? connectionString = null)
    {
        _connectionString = connectionString ?? @"Data Source=DENICA\SQLEXPRESS;Initial Catalog=PersonalFinanceDB;Integrated Security=True;Trust Server Certificate=True;";
    }

    public SqlConnection GetConnection()
        => new SqlConnection(_connectionString);
}

